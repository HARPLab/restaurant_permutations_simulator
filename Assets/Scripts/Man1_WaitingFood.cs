using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man1_WaitingFood : MonoBehaviour
{
    private Animator anim;
    public GameObject next_character;
    public GameObject food_on_table;
    public GameObject food_for_eating;
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
            transform.gameObject.active = false;
            next_character.SetActive(true);
            food_on_table.SetActive(false);
            food_for_eating.SetActive(true);
        }
    }
}
