using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static Transform targetPos;
    void Start()
    {
        targetPos = transform.transform;
    }
}
