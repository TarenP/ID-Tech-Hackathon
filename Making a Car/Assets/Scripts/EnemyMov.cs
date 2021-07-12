using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    Spawner spawner;

    private void Start()
    {
        spawner = GameObject.FindWithTag("Finish").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * spawner.speed * Time.deltaTime);
    }
    
}
