using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;

    public bool RightArm = true;
    public bool LeftArm = true;
    public bool LeftLeg = true;
    public bool RightLeg = true;
    public bool Head = true;

    bool shoot = false;

    public float reloadTime;

    public Camera fpsCam;
    public ParticleSystem Flash;
    public GameObject impact;

    public GameObject player;

    public Gun gun;

    public GameObject[] targets;
    void Update()
    {
        
        if (shoot == false)
        {
            shoot = true;
            StartCoroutine(StartShoot());
        }

    }
    IEnumerator StartShoot()
    {
        reloadTime = Random.Range(2, 4);
        if (gun.enemyHead == false)
        {
            reloadTime = 4f;
        }
        if (gun.enemyRightArm == false)
        {
            reloadTime = 6f;
        }
        if (gun.enemyRightArm == false && gun.enemyHead == false)
        {
            reloadTime = 8f;
        }

        yield return new WaitForSeconds(reloadTime);
        Shoot();
        shoot = false;
    }

    void Shoot()
    {

        fpsCam.transform.LookAt(targets[Random.Range(0, 13)].transform);

        Flash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Health health = player.GetComponent<Health>();
            

            if (hit.transform.tag == "head")
            {
                health.TakeDamage(50);
                Head = false;

            }
            if (hit.transform.tag == "right leg")
            {
                health.TakeDamage(20);
                Debug.Log("leg hit");
                RightLeg = false;
            }
            if (hit.transform.tag == "left leg")
            {
                health.TakeDamage(20);
                Debug.Log("leg hit");
                LeftLeg = false;
            }
            if (hit.transform.tag == "right arm")
            {
                health.TakeDamage(30);
                Debug.Log("arm hit");
                RightArm = false;
            }
            if (hit.transform.tag == "left arm")
            {
                health.TakeDamage(30);
                LeftArm = false;
            }
            else if (hit.transform.tag == "body")
            {
                health.TakeDamage(20);
            }
            Debug.Log("Player Health" + health.health);


            GameObject impactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
            
        }
    }
}
