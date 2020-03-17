using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private float _minPlayerDistance = 5;
    private Transform _playerTransform;

    [SerializeField]
    private UnityEvent _onInteract;

    private void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;

        if (_onInteract == null)
        {
            _onInteract = new UnityEvent();
        }
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
                        _onInteract.Invoke();
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
                        _onInteract.Invoke();
                    }
                }
            }
        }
    }
}
