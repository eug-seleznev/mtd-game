using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Mob : MonoBehaviour
{


    public float upForce = 1f;
    public float sideForce = 0.1f;
    public float startHealth = 500;
    private float health;
    public NavMeshAgent agent;
    private float startSpeed;

    public Image healthBar;
    
    void Start()
    {  
        health = startHealth;
        startSpeed = agent.speed;
        
        // float xForce = Random.Range(-sideForce, sideForce);
        // float yForce = Random.Range(upForce / 2f, upForce);
        // float zForce = Random.Range(-sideForce, sideForce);    
        
        // Vector3 force = new Vector3(xForce, yForce, 0);    

        // GetComponent<Rigidbody>().velocity = force;

        //agent.SetDestination(Target.targetPos.position);
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth; 

        if (health <= 0)
        {
            Die();
        }
    }

    public void ResetSpeed ()
    {
        agent.speed = startSpeed;
    }
    public void Slow(float slowAmount)
    {
        agent.speed = startSpeed * (1f - slowAmount);
    }

    void Die ()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        // if (transform.position.z == Target.targetPos.position.z)
        //     GameManager.SeparatePath();
        
    }
    
}
