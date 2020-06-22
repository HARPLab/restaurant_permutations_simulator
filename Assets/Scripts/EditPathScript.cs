using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class EditPathScript : MonoBehaviour
{
    public List<Transform> path_objs = new List<Transform>();
    Transform[] theArray;

    void Start()
    {
        ReadCSVFile();
    }
    
    void ReadCSVFile()
    {
        StreamReader strReader = new StreamReader("Assets/Scripts/TesterWaypoints.csv");
        bool endOfFile = false;
        int i = 0;
        while(!endOfFile)
        {
            string data_string = strReader.ReadLine();
            if (data_string == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_string.Split(',');
            
            GameObject emptyGameObj = new GameObject("PathPoint" + i.ToString());
            emptyGameObj.transform.parent = this.gameObject.transform;
            
            Debug.Log("here" + data_values[0]);
            float x = float.Parse(data_values[0]);
            Debug.Log(x);
            float y = float.Parse(data_values[1]);
            Debug.Log(y);
            float z = float.Parse(data_values[2]);
            Debug.Log(z);
            
            //need to convert data_values into something
            emptyGameObj.transform.position = new Vector3(x, y, z);
            
            path_objs.Add(emptyGameObj.transform);
            
            
            Debug.Log(data_values[0].ToString() + " " + data_values[1].ToString() + " " + data_values[2].ToString() );
        }
    }
    
    
}
