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

    public bool shoot;

    public Camera fpsCam;
    public ParticleSystem Flash;
    public GameObject impact;
    public GameObject bloodImpact;

    public GameObject player;

    public Gun gun;

    float chamberTime;
    public float ammoCount = 6;
    public float reloadTime = 8f;
    public bool inReload = false;

    public GameObject[] targets;
    void Update()
    {
        
        if (shoot == false && inReload == false)
        {
            ammoCount -= 1;
            shoot = true;
            StartCoroutine(StartShoot());
        }
        if (ammoCount <= 0)
        {
            inReload = true;
            StartCoroutine(Reload());
            ammoCount = 6;
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        inReload = false;
    }
    IEnumerator StartShoot()
    {
        chamberTime = 2f;
        /*if (gun.enemyHead == false)
        {
            reloadTime = 5f;
        }*/
        if (gun.enemyRightArm == false)
        {
            chamberTime = 6f;
        }
        /*if (gun.enemyRightArm == false && gun.enemyHead == false)
        {
            reloadTime = 8f;
        }*/

        yield return new WaitForSeconds(chamberTime);
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
                //Debug.Log("Head hit");
                health.TakeDamage(100);
                Head = false;

            }
            if (hit.transform.tag == "right leg")
            {
                health.TakeDamage(20);
                //Debug.Log("leg hit");
                RightLeg = false;
            }
            if (hit.transform.tag == "left leg")
            {
                health.TakeDamage(20);
                //Debug.Log("leg hit");
                LeftLeg = false;
            }
            if (hit.transform.tag == "right arm")
            {
                health.TakeDamage(30);
                //Debug.Log("arm hit");
                RightArm = false;
            }
            if (hit.transform.tag == "left arm")
            {
                health.TakeDamage(30);
                //Debug.Log("arm hit");
                LeftArm = false;
            }
            else if (hit.transform.tag == "body")
            {
                //Debug.Log("body");
                health.TakeDamage(20);
            }
            //Debug.Log("Player Health" + health.health);

            if (hit.transform.tag != "Map")
            {
                GameObject Blood = Instantiate(bloodImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(Blood, 2f);
            }
            else
            {
                GameObject impactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }
    }
}
