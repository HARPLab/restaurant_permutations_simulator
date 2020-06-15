using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man1_EatingSandWich : MonoBehaviour
{
    private Animator anim;
    public GameObject sandwich_on_the_plate;
    public GameObject sandwich_on_the_hand;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlateToMouth"))
        {
            sandwich_on_the_plate.gameObject.active = false;
            sandwich_on_the_hand.gameObject.active = true;
        }
    }
}
