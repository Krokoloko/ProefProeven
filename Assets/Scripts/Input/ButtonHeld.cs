using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHeld : MonoBehaviour
{
    private bool _pressed;

    [Serializable]
    public class WhileHeldEvent : UnityEvent{}

    [SerializeField]
    public WhileHeldEvent whileHeldEvent;

    private void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        
        // Pointer down event setup
        EventTrigger.Entry entryDown = new EventTrigger.Entry();
        entryDown.eventID = EventTriggerType.PointerDown;
        entryDown.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entryDown);
        
        // Pointer up event setup
        EventTrigger.Entry entryUp = new EventTrigger.Entry();
        entryUp.eventID = EventTriggerType.PointerUp;
        entryUp.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData)data); });
        trigger.triggers.Add(entryUp);
    }
    
    private void OnPointerDownDelegate(PointerEventData data)
    {
        _pressed = true;
    }
    
    private void OnPointerUpDelegate(PointerEventData data)
    {
        _pressed = false;
    }

    private void Update()
    {
        if (_pressed && whileHeldEvent != null)
        {
            whileHeldEvent.Invoke();
        }
    }
}
