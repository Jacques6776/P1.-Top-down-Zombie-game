using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    //Navigation and detection
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    
    //Provoked and distance from target
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Transform target;

    //Enemy health
    [SerializeField] int totalEnemyHealth = 3;

    //Attack damage
    [SerializeField] int damage = 50;
    PlayerController targetHealth;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetHealth = FindObjectOfType<PlayerController>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    void EngageTarget()
    {
        FaceTarget();

        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    public void AttackTarget()
    {
        targetHealth.PlayerTakesDamage(damage);
        //Debug.Log("You have been attacked");
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessDamageTaken();
        
        if(totalEnemyHealth <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessDamageTaken()
    {
        totalEnemyHealth--;
        Debug.Log("Ouch");
    }

    void KillEnemy()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
