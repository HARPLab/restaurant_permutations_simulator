using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Server : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public GameObject food;
    public GameObject food2;
    public int stage;
    public float speed;

    void Start()
    {
        stage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(stage == 1)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (Vector3.Distance(transform.position, target.position) < 0.1)
            {
                stage = 2;
            }

        }

        else if(stage == 2)
        {
            food.gameObject.active = false;
            food2.gameObject.active = true;
            stage = 3;
        }

        else if(stage == 3)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
        }

    }
}