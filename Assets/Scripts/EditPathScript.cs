using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EditPathScript : MonoBehaviour
{
    public List<Transform> path_objs = new List<Transform>();
    Transform[] theArray;
    
    public Transform waypoint1;
    public Transform waypoint2;
    public Transform waypoint3;
    
    private int numWaypoints = 3;
    
    void Start()
    {
        theArray = new Transform[numWaypoints];
        theArray[0] = waypoint1;
        theArray[1] = waypoint2;
        theArray[2] = waypoint3;
        path_objs.Clear();
        
        foreach (Transform path_obj in theArray){
            if(path_obj != this.transform)
            {
                path_objs.Add(path_obj);
            }
        } 
//        
//        for(int i = 0; i < path_objs.Count; i++)
//        {
//            Vector3 position = path_objs[i].position;
//            if (i > 0)
//            {
//                Vector3 previous = path_objs[i - 1].position;
//                if(i>0)
//                {
//                    previous = path_objs[i-1].position;
//                    Gizmos.DrawLine(previous,position);
//                    Gizmos.DrawWireSphere(position, 0.3f);
//                }
//            }
//        }
    }
    
    
}
