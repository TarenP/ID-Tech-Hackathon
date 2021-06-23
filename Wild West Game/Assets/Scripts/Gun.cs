using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;

    public bool enemyRightArm = true;
    public bool enemyLeftArm = true;
    public bool enemyLegs = true;
    public bool enemyHead = true;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();

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

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
