using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveOnPathScript : MonoBehaviour
{

    public EditPathScript PathToFollow;
    
    public int CurrentWayPointID = 0;
    public float speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;
    private Animator anim;
    private int stage;
    
    Vector3 last_position;
    Vector3 current_position;
    
    // Start is called before the first frame update
    void Start()
    {
        //animation
        anim = GetComponent<Animator>();
        stage = 1; 
        
        
        PathToFollow = GameObject.Find(pathName).GetComponent<EditPathScript>();
        last_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //while the server is moving
        if(stage == 1){
            anim.SetBool("isWalking", true);
            Debug.Log("walking");
        
    
            float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);

            var rotation = Quaternion.LookRotation(PathToFollow.path_objs[CurrentWayPointID].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            if(distance <= reachDistance)
            {
                CurrentWayPointID++;
            }
            
            if(CurrentWayPointID >= PathToFollow.path_objs.Count)
            {
                stage = 2;
            }
        }
        
        //server has reached stopping point
        if(stage == 2)
        {
            anim.SetBool("isWalking", false);
            Debug.Log("idle");
        }
    }
}
