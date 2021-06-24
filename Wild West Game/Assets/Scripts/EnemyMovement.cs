using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Animator anim;
    public int speed = 5;
    Rigidbody rb;
    public Gun gun;

    public GameObject player;

    public NavMeshAgent agent;
    public LayerMask EnemyAIGround;
    bool walkPointSet;
    public Vector3 walkPoint;
    public float walkPointRange;

    public bool move;

    Animator animator;
    // Update is called once per frame

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (move == true)
        {
            if (gun.enemyLeftLeg == false || gun.enemyRightLeg == false)
            {
                speed = 2;
            }
            if (gun.enemyLeftLeg == false && gun.enemyRightLeg == false)
            {
                speed = 0;
            }
            Patrolling();
            if (agent.velocity.magnitude > 0)
            {
                animator.Play("Forwards");
            }
        }
    }
    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            transform.LookAt(player.transform);
            agent.speed = speed;
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, EnemyAIGround))
        {
            walkPointSet = true;
        }

    }

}


