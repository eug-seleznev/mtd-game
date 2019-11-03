using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Mob targetMob;
    public Mob mobScript;

    [Header("Attributes")]
    [SerializeField] private float range = 15f;
    [SerializeField] private float fireRate = 1f;
    private float fireCountdown = 0f;
    [SerializeField] private float turnSpeed = 10f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 30;
    public LineRenderer lineRenderer;
    public ParticleSystem laserImpactEffect;
    public float slowAmount = 0.5f;


    [Header("Setup Fields")]
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private Transform partToRotate;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    

    
    void Start()
    {
        InvokeRepeating ("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetMob = nearestEnemy.GetComponent<Mob>();
        } else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            if(useLaser)
            {
                if(lineRenderer.enabled)
                    lineRenderer.enabled = false;
                    laserImpactEffect.Stop();
            }

            
            return;
        }

        LookAtTarget();

        if (useLaser)
        {
            Laser();
        }else{
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void Laser ()
    {   

        targetMob.TakeDamage(damageOverTime*Time.deltaTime);
        targetMob.Slow(slowAmount);
        

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserImpactEffect.Play(); 
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        laserImpactEffect.transform.position = target.position + dir.normalized * 0.5f;
        laserImpactEffect.transform.rotation = Quaternion.LookRotation(dir);

    }

    void LookAtTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
    }

    void  Shoot ()
    {
        GameObject bulletGO = (GameObject) Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
