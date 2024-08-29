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
    
    [SerializeField] bool isDead = false;

    //Attack damage
    [SerializeField] int damage = 50;
    PlayerController targetHealth;
    
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetHealth = FindObjectOfType<PlayerController>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        if(isDead)
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
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

    private void EngageTarget()
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

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);        
    }

    public void DamagePlayer()
    {
        targetHealth.PlayerTakesDamage(damage);
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessDamageTaken();
        
        if(totalEnemyHealth <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessDamageTaken()
    {
        totalEnemyHealth--;
        ChaseTarget();
    }

    private void KillEnemy()
    {
        if(isDead) return;
        GetComponent<Animator>().SetTrigger("die");
        isDead = true;
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
