using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator anim;
    public int speed = 5;
    Rigidbody rb;
    public Gun gun;

    // Update is called once per frame
    void Update()
    {
        if (gun.enemyLeftLeg == false || gun.enemyRightLeg == false)
        {
            speed = 2;
        }
        if (gun.enemyLeftLeg == false && gun.enemyRightLeg == false)
        {
            speed = 0;
        }
        if (Input.GetKey(KeyCode.U))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.I))
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.O))
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.P))
            transform.Translate(Vector3.back * speed * Time.deltaTime);


    }

}


