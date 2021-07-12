using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] Spawners;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        Instantiate(enemy, Spawners[Random.Range(0, 7)].transform);
        yield return new WaitForSeconds(60f);
    }
}
