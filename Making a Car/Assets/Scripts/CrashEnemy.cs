using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit car");
        if (other.gameObject.tag == "Player")
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            Debug.Log("End");
        }


    }
}
