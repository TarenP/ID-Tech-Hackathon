using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float range = 100f;

    public bool enemyRightArm = true;
    public bool enemyLeftArm = true;
    public bool enemyLeftLeg = true;
    public bool enemyRightLeg = true;
    public bool enemyHead = true;

    public EnemyGun gun;

    public GameObject Enemy;

    public bool ableToShoot;
    public float chamberTime = 1f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject bloodImpact;

    public Vector3 upRecoil;
    Vector3 originalRotation;

    public float ammoCount = 6;
    public float reloadTime = 8f;
    public bool inReload = false;

    void Start()
    {
        originalRotation = transform.localEulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ableToShoot == true && inReload == false)
        {
            ammoCount -= 1;
            StartCoroutine(Main());
            Shoot();
            ableToShoot = false;
            StartCoroutine(Shooter());

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

    private void AddRecoil()
    {
        transform.localEulerAngles += upRecoil;
    }

    private void StopRecoil()
    {
        transform.localEulerAngles = originalRotation;

    }
    IEnumerator Main()
    {
        AddRecoil();
        yield return new WaitForSeconds(0.7f);
        StopRecoil();
    }

    IEnumerator Shooter()
    {
        /*if (gun.Head == false)
        {
            reloadTime = 4f;
        }*/
        if (gun.RightArm == false)
        {
            chamberTime = 4f;
        }
        /*if (gun.RightArm == false && gun.Head == false)
        {
            reloadTime = 8f;
        }*/
        yield return new WaitForSeconds(chamberTime);
        ableToShoot = true;
    }
    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            EnemyHealth health = Enemy.GetComponent<EnemyHealth>();
            
            
            if (hit.transform.tag == "enemy head")
            {
                health.TakeDamage(100);
                enemyHead = false;
                //Debug.Log("Headshot");
            }
            if (hit.transform.tag == "enemy right leg")
            {
                health.TakeDamage(20);
                enemyRightLeg = false;
                //Debug.Log("Right Leg");
            }
            if (hit.transform.tag == "enemy left leg")
            {
                health.TakeDamage(20);
                enemyLeftLeg = false;
                //Debug.Log("Left Leg");
            }
            if (hit.transform.tag == "enemy right arm")
            {
                health.TakeDamage(30);
                enemyRightArm = false;
                //Debug.Log("Right Arm");
            }
            if (hit.transform.tag == "enemy left arm")
            {
                health.TakeDamage(30);
                enemyLeftArm = false;
                //Debug.Log("Left Arm");
            }
            else if (hit.transform.tag == "enemy body")
            {
                health.TakeDamage(20);
                //Debug.Log("BodyShot");
            }
            Debug.Log("Enemy Health" + health.health);


            if (hit.transform.tag != "Map")
            {
                GameObject Blood = Instantiate(bloodImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(Blood, 2f);
            }
            else
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
            
        }
    }
}
