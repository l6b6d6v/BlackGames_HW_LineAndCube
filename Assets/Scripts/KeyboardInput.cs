using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.RectTransform;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private GameObject _target;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis(Axis.Horizontal);
        float vertical = Input.GetAxis(Axis.Vertical);

        _movement.Move(new Vector3(horizontal, 0, vertical));

        if (horizontal == 0 && vertical == 0)
            _movement.FreezePosition();
        else
            _target.SetActive(false);
    }
}
