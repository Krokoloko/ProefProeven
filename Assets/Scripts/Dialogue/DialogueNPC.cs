using System;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    [Serializable]
    public class DialogueData
    {
        public string name;
        public Sprite sprite;
        public string[] dialogueLines;
    }

    [SerializeField]
    private DialogueData[] _dialogueData;

    [SerializeField]
    private float _minPlayerDistance = 5;
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _playerTransform.position) < _minPlayerDistance)
        {
            // Touch screen input
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    if (raycastHit.collider.gameObject == gameObject)
                    {
                        FindObjectOfType<DialogueBox>().StartDialogue(_dialogueData);
                    }
                }
            }

            // Mouse inpput
            if (Input.GetMouseButtonDown(0))
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    if (raycastHit.collider.gameObject == gameObject)
                    {
                        FindObjectOfType<DialogueBox>().StartDialogue(_dialogueData);
                    }
                }
            }
        }
    }
}
