using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _movementObject;

    [SerializeField]
    private double _movementMultiplier = 1.5f;

    private Vector3 _moveTo;

    private float _velocity;
    public float Velocity
    {
        get { return _velocity; }
        private set { _velocity = Velocity; }
    }

    void Awake()
    {
        _movementObject = (!_movementObject) ? transform : _movementObject;    
    }

    public void MoveForward(JoystickData data)
    {
        _velocity = (float)(data.distance * _movementMultiplier) * Time.deltaTime;
        _moveTo = Vector3.forward * _velocity;
        _movementObject.Translate(_moveTo);
        if (data.eventType == JoystickeventState.Exit)
        {
            _velocity = 0;
        }
    }
}
