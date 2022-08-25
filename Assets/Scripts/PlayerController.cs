using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public FixedJoystick VJoystick;
    public Rigidbody rb;
    public GameObject target;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (VJoystick.Horizontal == 0)
            {
                MoveToTarget(true);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit Position;
                if (Physics.Raycast(ray, out Position))
                {
                    target.transform.position = new Vector3(Position.point.x, Position.point.y, 0);
                }
            }
        }

        if (VJoystick.Horizontal != 0)
        {
            MoveToTarget(false);
            rb.AddForce(Vector3.right * VJoystick.Horizontal * speed * 5, ForceMode.VelocityChange);
        }

        if (target.activeSelf == true)
        {
            MoveToTarget(true);
            if (target.transform.position.x - transform.position.x > 0)
            {
                rb.AddForce(Vector3.right * speed, ForceMode.VelocityChange);
            }

            if (target.transform.position.x - transform.position.x < 0)
            {
                rb.AddForce(Vector3.left * speed, ForceMode.VelocityChange);
            }
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void MoveToTarget(bool canMove)
    {
        target.SetActive(canMove);
    }
}
