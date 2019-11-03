using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public GameObject impactEffect;
    public int damage = 10;
    [SerializeField] float speed = 70f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Start()
    {

    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate (dir.normalized * distanceThisFrame, Space.World);

    }

    void Damage (Transform mob)
    {
        Mob m = mob.GetComponent<Mob>();

        if (m != null)
        {
            m.TakeDamage(damage);
        }

    }

    void HitTarget ()
    {
        GameObject effectIns = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Damage(target);
        //Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
