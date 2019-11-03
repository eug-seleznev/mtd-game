using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    public Camera cam;
    public GameObject tower;
    enum State {idle, build}
    State state = State.idle;
    
    void Start()
    {
        
    }

    public void EnableBuildMode()
    {
        state = State.build;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.build)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(tower, hit.point, Quaternion.identity);
                }
                state = State.idle;
            }
        }
    }
}
