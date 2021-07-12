using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 5;
    public int rotateSpeed = 5;
    private bool jumping = false;
    float jumpForce = 8f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetButtonDown("Jump") && jumping == false)
        {
            jumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball")){
            Debug.Log("Sphere Collided");
        }
        if (other.gameObject.CompareTag("Floor"))
        {
            jumping = false;
        }
    }

}
