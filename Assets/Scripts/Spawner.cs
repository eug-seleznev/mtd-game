using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mobPrefab;
    public int  MobsCount = 15;
    public Transform Base1;
    public Transform Base2;
    [HideInInspector]    public bool baseSwitch = false;

    //Mob mobInstance;

    void Start()
    {  
        // for (int i = 0; i < MobsCount; i++)
        // {
        //     Invoke("SpawnMobs", i);
        // }
    }

    public void StartSpawnWave()
    {
        for (int i = 0; i < MobsCount; i++)
        {
            Invoke("SpawnMobs", i);
        }
    }

    void Update()
    {
        
    }

    void SpawnMobs()
    {
        GameObject mobInstance = (GameObject) Instantiate(mobPrefab, transform.position, Quaternion.identity);
        var mobIns = mobInstance.GetComponent<Mob>();
        if (baseSwitch)
        {          
            mobIns.agent.SetDestination(Base1.transform.position);
            baseSwitch = false;
        }else{         
            mobIns.agent.SetDestination(Base2.transform.position);
            baseSwitch = true;
        }
    }

}
