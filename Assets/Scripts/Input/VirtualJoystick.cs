using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class JoystickData : EventArgs
{
    public Vector2 direction;
    public float distance;
}
[System.Serializable]
public class JoystickEvent : UnityEvent<JoystickData> { }

public class VirtualJoystick : MonoBehaviour
{
    [SerializeField]
    private double _maxOffset;

    private bool _joystickDetected = false;
    private int _touchIndex = -1;
    private int _touchTracker;
    private Vector2 _centerPosition;
    private Vector2 _touchPosition;

    [SerializeField]
    private Transform _innerCircle;
    [SerializeField]
    private Transform _outerCircle;

    [SerializeField]
    private JoystickEvent _onJoystickEnter;
    [SerializeField]
    private JoystickEvent _onJoystickStay;
    [SerializeField]
    private JoystickEvent _onJoystickExit;



    // Start is called before the first frame update
    void Start()
    {
        _touchPosition = _outerCircle.GetComponent<RectTransform>().position;
        _centerPosition = _outerCircle.GetComponent<RectTransform>().position;
        Debug.Log(_centerPosition);
    }

    //Gets the Vector2 of the joystick position in a normalised value comparing with the centerposition
    public Vector2 GetVector2()
    {
        return (_centerPosition - _touchPosition).normalized;
    }

    //Gets the distance between the touch position and center position of the joystick
    private float GetDistance()
    {
        return Vector2.Distance(_centerPosition,_touchPosition);
    }

    //Gets the normalised travel between the center of the joystick and the innerCircle/joystick itself
    public float GetNormalisedDistance()
    {
        return Mathf.Min(Vector2.Distance(_centerPosition, _innerCircle.position)/(float)_maxOffset,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (_touchIndex >= 0)
        {
            JoystickData data = new JoystickData();

            Touch touch = Input.GetTouch(_touchIndex);
            
            _touchPosition = touch.position;

            float distance = GetDistance();

            //The conditions to trigger OnJoystickEnter is if the touch position is in range of the joystick and if it hasn't been touched
            if (distance <= _maxOffset && !_joystickDetected)
            {
                _joystickDetected = true;

                //Activate OnJoystickEnter event unless it has no subscribed actions
                data.direction = GetVector2();
                data.distance = GetNormalisedDistance();
                _onJoystickEnter?.Invoke(data);
            }
            if (_joystickDetected)
            {
                //If the touch isn't active, then the position of the innerCircle/joystick will be centered
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    _innerCircle.position = _outerCircle.position;
                    _joystickDetected = false;
                    _touchPosition = _centerPosition;
                    
                    //Activate OnJoystickExit event unless it has no subscribed actions
                    data.direction = GetVector2();
                    data.distance = GetNormalisedDistance();
                    _onJoystickExit?.Invoke(data);
                }
                else
                {
                    //This calculation clamps the innerCircle/joystick inside the maxOffset
                    Vector2 newPosition = (_touchPosition - _centerPosition).normalized*Mathf.Clamp(distance,0,(float)_maxOffset)+_centerPosition;

                    //Updates position of the innerCircle/joystick
                    data.direction = GetVector2();
                    data.distance = GetNormalisedDistance();

                    //Activate OnJoystickStay event unless it has no subscribed actions
                    _onJoystickStay?.Invoke(data);

                    //Updates position of the innerCircle/Joystick
                    _innerCircle.position = newPosition;
                }
            }
        }
        if (Input.touchCount != _touchTracker && !_joystickDetected)
        {
            _touchTracker = Input.touchCount;
            _touchIndex = _touchTracker - 1;
            return;
        }
    }
}
