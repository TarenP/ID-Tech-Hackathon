using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    public float chamber = 1f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject bloodImpact;

    public Vector3 upRecoil;
    Vector3 originalRotation;

    public float ammoCount = 6;
    public float reloadTime = 8f;
    public bool inReload = false;

    public Text score;
    public int scr = 0;
    public AudioSource chamberFX;
    public AudioSource chamberFXLong;
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
        chamberFX.Play();
        Debug.Log("short");

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
            chamber = 3.3f;
        }
        /*if (gun.RightArm == false && gun.Head == false)
        {
            reloadTime = 8f;
        }*/
        yield return new WaitForSeconds(chamber);
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
                             scr += 1200;
                             score.text = "Score: " + scr;

                        }
                        if (hit.transform.tag == "enemy right leg")
                        {
                            health.TakeDamage(20);
                            enemyRightLeg = false;
                            //Debug.Log("Right Leg");
                            scr+= 200;
                            score.text = "Score: " + scr;

                        }
                        if (hit.transform.tag == "enemy left leg")
                        {
                            health.TakeDamage(20);
                            enemyLeftLeg = false;
                            //Debug.Log("Left Leg");

                            scr+= 200;
                            score.text = "Score: " + scr;
                        }
                        if (hit.transform.tag == "enemy right arm")
                        {
                            health.TakeDamage(30);
                            enemyRightArm = false;
                            //Debug.Log("Right Arm");

                            scr+= 300;
                                            score.text = "Score: " + scr;
                        }
                        if (hit.transform.tag == "enemy left arm")
                        {
                            health.TakeDamage(30);
                            enemyLeftArm = false;
                            //Debug.Log("Left Arm");

                            scr+= 300;
                                            score.text = "Score: " + scr;
                        }
                        else if (hit.transform.tag == "enemy body")
                        {
                            health.TakeDamage(20);
                            //Debug.Log("BodyShot");

                            scr+= 100;
                                            score.text = "Score: " + scr;
                        }
            //Debug.Log("Enemy Health" + health.health);


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
