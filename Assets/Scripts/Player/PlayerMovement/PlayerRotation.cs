using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private Transform _rotateTransform;

    void Awake()
    {
        _rotateTransform = (!_rotateTransform) ? transform : _rotateTransform;
    }

    public void RotateTransform(JoystickData data)
    {
        Vector3 normalizedVector3Rotation  = new Vector3(-data.direction.x, 0, -data.direction.y);
        _rotateTransform.LookAt(_rotateTransform.position+normalizedVector3Rotation);
    }
}
