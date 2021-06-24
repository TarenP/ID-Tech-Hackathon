using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPaces : MonoBehaviour
{
    public Gun playerGun;
    public EnemyGun enemyGun;
    public EnemyMovement enemyMov;
    public Movement playerMov;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
