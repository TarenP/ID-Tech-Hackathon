using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public int speed = 5;
    Rigidbody rb;
    float jumpForce = 4.0f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
                        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.A))
                        transform.Translate(Vector3.left * speed * Time.deltaTime);

                if(Input.GetKey(KeyCode.D))
                        transform.Translate(Vector3.right * speed * Time.deltaTime);

                if(Input.GetKey(KeyCode.S))
                        transform.Translate(Vector3.back * speed * Time.deltaTime);

                if(Input.GetKey(KeyCode.Space) && jump==false){
                    rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
                    jump = true;
                }
    }

    void OnCollisionEnter(Collision other){
            if(other.gameObject.CompareTag("Floor")){
                jump = false;
            }
        }
}
