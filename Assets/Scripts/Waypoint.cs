using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform target;
    public GameObject this_character;
    public GameObject next_character;
    public float speed;
    private Animator anim;
    private int stage;


    void Start()
    {
        anim = GetComponent<Animator>();
        stage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (stage == 1)
        {
            anim.SetBool("IsWalking", true);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (Vector3.Distance(transform.position, target.position) < 0.1)
            {
                stage = 2;
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsTurning", true);
            }
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            this_character.SetActive(false);
            next_character.SetActive(true);
        }




    }

}

