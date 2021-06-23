using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;

    bool enemyRightArm = true;
    bool enemyLeftArm = true;
    bool enemyLegs = true;
    bool enemyHead = true;

    bool shoot = false;

    public Camera fpsCam;
    public ParticleSystem Flash;
    public GameObject impact;

    public Gun gun;

    public GameObject[] targets;
    // Update is called once per frame
    private void Start()
    {

    }
    void Update()
    {
        if (gun.enemyRightArm == true && shoot == false)
        {
            shoot = true;
            StartCoroutine(StartShoot());
        }
        
    }
    IEnumerator StartShoot()
    {

        yield return new WaitForSeconds(Random.Range(3, 6));
        Shoot();
        shoot = false;
        Debug.Log("looking");
    }

    void Shoot()
    {

        fpsCam.transform.LookAt(targets[Random.Range(0, 32)].transform);

        Flash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            if (hit.transform.name == "enemy head")
            {
                enemyHead = false;
            }
            if (hit.transform.name == "enemy legs")
            {
                enemyLegs = false;
            }
            if (hit.transform.name == "enemy right arm")
            {
                enemyRightArm = false;
            }
            if (hit.transform.name == "enemy left arm")
            {
                enemyLeftArm = false;
            }


            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
