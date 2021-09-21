using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveOnPathScript : MonoBehaviour
{

    public EditPathScript PathToFollow;
    
    public int CurrentWayPointID = 0;
    public float speed;
    public float rotationSpeed = 10.0f;
    public string pathName;
    private Animator anim;
    private int stage;
    float current_speed = 0f;
    int substep_index = 0;
    float timer = 0f;

    public int num_steps = 10;
    
    Vector3 last_position;
    Vector3 current_position;
    
    // Start is called before the first frame update
    void Start()
    {
        //animation
        anim = GetComponent<Animator>();
        stage = 1; 
        
        
        PathToFollow = GameObject.Find(pathName).GetComponent<EditPathScript>();
        CurrentWayPointID = 1;
        last_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        //while the server is moving
        if(stage == 1){
            anim.SetBool("isWalking", true);
           // Debug.Log("walking");
        
            current_speed = (Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, PathToFollow.path_objs[CurrentWayPointID - 1].position) / (num_steps * Time.deltaTime));
            
            float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * current_speed);

            var rotation = Quaternion.LookRotation(PathToFollow.path_objs[CurrentWayPointID].position - transform.position);
            transform.rotation = rotation; //Quaternion.Slerp(transform.rotation, rotation, 1); //Time.deltaTime * rotationSpeed);
            

            // Debug.Log(transform.rotation.x);
            substep_index++;
            if(substep_index >= num_steps) //distance <= reachDistance
            {
                CurrentWayPointID++;
                substep_index = 0;
                Debug.Log("Printing timestep of " + timer);
            }
            
            if(CurrentWayPointID >= PathToFollow.path_objs.Count)
            {
                stage = 2;
                Debug.Log("Finished at!");
                Debug.Log(timer);
            }
        }
        
        //server has reached stopping point
        if(stage == 2)
        {
            anim.SetBool("isWalking", false);
            //Debug.Log("idle");
        }
    }
}