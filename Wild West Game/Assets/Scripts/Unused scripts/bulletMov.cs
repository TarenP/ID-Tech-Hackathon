using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMov : MonoBehaviour
{
    public float bulletDeleteTime = 5f;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, bulletDeleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
