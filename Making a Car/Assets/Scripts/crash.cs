using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit car");
        if (other.gameObject.tag == "Respawn")
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            Debug.Log("End");
        }


    }
}
