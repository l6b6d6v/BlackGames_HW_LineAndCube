using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private GameObject _target;

    private void FixedUpdate()
    {
        float horizontal = _fixedJoystick.Horizontal;
        float vertical = _fixedJoystick.Vertical;

        _movement.Move(new Vector3(horizontal, 0, vertical));
        if (horizontal == 0 && vertical == 0)
            _movement.FreezePosition();
        else
            _target.SetActive(false);
    }
}
