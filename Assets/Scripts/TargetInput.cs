using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private GameObject _target;
    private Vector3 _direction;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Position;
            if (Physics.Raycast(ray, out Position))
            {
                _target.transform.position = new Vector3(Position.point.x, Position.point.y, Position.point.z);
                _target.SetActive(true);
                var heading = _target.transform.position - transform.position;
                var distance = heading.magnitude;
                _direction = heading / distance;
            }
        }

        if (_target.activeSelf == true)
        {
            _movement.Move(new Vector3(_direction.x, 0, _direction.z));
            if (_target.transform.position == transform.position)
            {
                _target.SetActive(false);
                _movement.FreezePosition();
            }
        }
        else
            _movement.FreezePosition();
    }
}
