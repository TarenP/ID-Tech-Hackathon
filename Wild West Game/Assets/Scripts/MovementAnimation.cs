using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    public Animator anim;
    public EnemyGun gun;

    public Movement mov;
    // Start is called before the first frame update
    void Start()
    {
        mov = mov.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mov.move == true)
        {
            if (Input.anyKey)
            {
                if (gun.LeftLeg == true || gun.RightLeg == true)
                {
                    if (Input.GetKeyDown("w"))
                    {
                        anim.Play("forwards");
                    }
                    if (Input.GetKeyDown("s"))
                    {
                        anim.Play("backwards");
                    }
                    if (Input.GetKeyDown("a"))
                    {
                        anim.Play("left");
                    }
                    if (Input.GetKeyDown("d"))
                    {
                        anim.Play("right");
                    }
                }

            }
            else
            {
                anim.Play("idle");
            }
        }
    }
}
