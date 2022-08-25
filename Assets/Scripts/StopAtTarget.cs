using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAtTarget : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
