using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man1_LookingAtTheMenu : MonoBehaviour
{
    private Animator anim;
    public GameObject this_character;
    public GameObject next_character;
    public GameObject server_for_order;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            this_character.SetActive(false);
            next_character.SetActive(true);
            server_for_order.SetActive(true);
        }
    }
}
