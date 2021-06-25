using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StartPaces : MonoBehaviour
{
    public Gun playerGun;
    public EnemyGun enemyGun;
    public EnemyMovement enemyMov;
    public Movement playerMov;
    public Animator enemyAnim;
    public Animator playerAnim;
    public GameObject player;
    public GameObject enemy;
    public NavMeshAgent agent;

    public Camera camPaces;
    public Camera FPSCam;

    public bool doPaces = true;

    public Canvas canvas;

    private void Awake()
    {
        playerGun = playerGun.GetComponent<Gun>();
        playerMov = playerMov.GetComponent<Movement>();
        enemyGun = enemyGun.GetComponent<EnemyGun>();
        enemyMov = enemyMov.GetComponent<EnemyMovement>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        playerGun.ableToShoot = false;
        enemyGun.shoot = true;
        enemyMov.move = false;
        playerMov.move = false;
        agent = agent.GetComponent<NavMeshAgent>();
        agent.enabled = !agent.enabled;
        canvas = canvas.GetComponent<Canvas>();
        canvas.enabled = !canvas.enabled;
        StartCoroutine(Paces());

    }
    // Update is called once per frame
    void Update()
    {
        if (doPaces == true)
        {
            
            enemyAnim.Play("Forwards");
            player.transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            enemy.transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            playerAnim.Play("forwards");

        }
    }
    IEnumerator Paces()
    {
        
        yield return new WaitForSeconds(7);
        camPaces.enabled = !camPaces.enabled;
        FPSCam.enabled = !FPSCam.enabled;

        player.transform.Rotate(0, 180, 0, Space.Self);
        enemy.transform.Rotate(0, 180, 0, Space.Self);
        doPaces = false;
        playerGun.ableToShoot = true;
        enemyGun.shoot = false;
        enemyMov.move = true;
        playerMov.move = true;
        agent.enabled = !agent.enabled;

        canvas.enabled = !canvas.enabled;
    }
}
