﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandWichMovement : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public int stage;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        stage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (stage == 1)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (Vector3.Distance(transform.position, target.position) < 0.1)
            {
                stage = 2;
            }

        }

        else if (stage == 2)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
            if (Vector3.Distance(transform.position, target2.position) < 0.1)
            {
                stage = 2;
            }
        }
    }
}