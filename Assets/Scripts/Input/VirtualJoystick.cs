using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class VirtualJoystick : MonoBehaviour
{
    [SerializeField]
    private float _maxOffset;

    private bool _joystickDetected = false;

    private Vector2 _pointA;
    private Vector2 _pointB;

    [SerializeField]
    private Transform _innerCircle;
    [SerializeField]
    private Transform _outerCircle;

    [SerializeField]
    private UnityEvent OnJoystickEnter;
    [SerializeField]
    private UnityEvent OnJoystickStay;
    [SerializeField]
    private UnityEvent OnJoystickExit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IsPressed()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_joystickDetected);
        if (Input.touchCount > 0)
        {
            Debug.Log("touch detected");
            Touch touch = Input.GetTouch(0);

            if (_outerCircle.GetComponent<RectTransform>().)
            {
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    _innerCircle.position = _outerCircle.position;
                    OnJoystickExit?.Invoke();
                }
                else
                {
                    _innerCircle.position = touch.position;
                }
            }            
        }
        _joystickDetected = false;
    }
}
