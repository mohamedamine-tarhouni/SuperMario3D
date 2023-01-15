using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distance;
    void Update()
    {

        transform.position = new Vector3(target.transform.position.x, target.transform.position.y+4f, target.transform.position.z-distance);

    }
}

