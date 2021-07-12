using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float speed = 400f;
    private bool on = false;
    public GameObject Enemy;
    public GameObject[] spawners;
    public GameObject[] buildingspawners;
    public GameObject[] Buildings;
    private void Start()
    {
        int first = Random.Range(0, 3);
        int second = Random.Range(0, 3);

        while (first == second)
        {
            first = Random.Range(0, 3);
            second = Random.Range(0, 3);
        }
        Instantiate(Enemy, spawners[first].transform.position, spawners[first].transform.rotation);
        Instantiate(Enemy, spawners[second].transform.position, spawners[second].transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.gameObject.tag == "Respawn")
        {
            Destroy(other.gameObject);
            on = true;
        }
        

    }

    public void Update()
    {
        
        if (on == true)
        {
            //StartCoroutine(waiter());
            int first = Random.Range(0, 3);
            int second = Random.Range(0, 3);

            while (first == second)
            {
                first = Random.Range(0, 3);
                second = Random.Range(0, 3);
            }
            Instantiate(Enemy, spawners[first].transform.position, spawners[first].transform.rotation);
            Instantiate(Enemy, spawners[second].transform.position, spawners[second].transform.rotation);
            speed += 10f;
            Debug.Log(speed);
        }
        on = false;
        score.scoreValue = speed - 300;

    }
    /*IEnumerator waiter()
    {
        int build0 = Random.Range(0, 3);
        int build1 = Random.Range(0, 3);
        if (build0 == 2)
        {
            buildingspawners[0].transform.Translate(-787, 70, 60);
        }
        else if (build0 == 1)
        {
            buildingspawners[0].transform.Translate(-787, -25, 60);
        }
        if (build0 == 0)
        {
            buildingspawners[0].transform.Translate(-787, 112, 110);
        }
        if (build1 == 2)
        {
            buildingspawners[1].transform.Translate(-787, 70, -60);
            buildingspawners[1].transform.Rotate(0, -90, 0);
        }
        else if (build1 == 1)
        {
            buildingspawners[0].transform.Translate(-787, -25, -60); 
            buildingspawners[1].transform.Rotate(0, -90, 0);
        }
        if (build1 == 0)
        {
            buildingspawners[0].transform.Translate(-787, 112, -110);
            buildingspawners[1].transform.Rotate(0, -90, 0);
        }
        Instantiate(Buildings[build0], buildingspawners[0].transform.position, buildingspawners[0].transform.rotation);
        Instantiate(Buildings[build1], buildingspawners[1].transform.position, buildingspawners[1].transform.rotation);
        yield return new WaitForSeconds(Random.Range(1, 5));


    }*/
}
