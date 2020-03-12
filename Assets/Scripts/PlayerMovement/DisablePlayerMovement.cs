using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerMovementOptions {Movement, Rotation, Roll};

public class DisablePlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _movement;

    [SerializeField]
    private PlayerRotation _rotation;

    [SerializeField]
    private PlayerRoll _roll;

    void Awake()
    {
        _movement = (!_movement) ? GetComponent<PlayerMovement>() : _movement;
        _rotation = (!_rotation) ? GetComponent<PlayerRotation>() : _rotation;
        _roll = (!_roll) ? GetComponent<PlayerRoll>() : _roll;
    }
    
    public void DisableMovementOption(PlayerMovementOptions option)
    {
        switch (option)
        {
            case PlayerMovementOptions.Movement:
                _movement.enabled = false;
                break;

            case PlayerMovementOptions.Roll:
                _roll.enabled = false;
                break;
            
            case PlayerMovementOptions.Rotation:
                _rotation.enabled = false;
                break;

            default:
                break;
        }
    }

    public void EnableMovementOption(PlayerMovementOptions option)
    {
        switch (option)
        {
            case PlayerMovementOptions.Movement:
                _movement.enabled = true;
                break;

            case PlayerMovementOptions.Roll:
                _roll.enabled = true;
                break;

            case PlayerMovementOptions.Rotation:
                _rotation.enabled = true;
                break;

            default:
                break;
        }
    }

    public void EnableMovement()
    {
        _movement.enabled = true;
    }

    public void DisableMovement()
    {
        _movement.enabled = false;
    }

    public void EnableRotation()
    {
        _rotation.enabled = true;
    }

    public void DisableRotation()
    {
        _rotation.enabled = false;
    }

    public void EnableRoll()
    {
        _roll.enabled = true;
    }

    public void DisableRoll()
    {
        _roll.enabled = false;
    }
}
