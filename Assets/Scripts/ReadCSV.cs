using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadCSV : MonoBehaviour
{
    public Transform[] Waypoints;
    // Start is called before the first frame update
    void Start()
    {
        //ReadCSVFile();
    }

    
    void ReadCSVFile()
    {
        Debug.Log("Start");
        StreamReader strReader = new StreamReader("Assets/Scripts/TesterWaypoints.csv");
        bool endOfFile = false;
        while(!endOfFile)
        {
            string data_string = strReader.ReadLine();
            if (data_string == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_string.Split(',');
            Debug.Log(data_values[0].ToString() + " " + data_values[1].ToString() + " " + data_values[2].ToString() );
            Debug.Log("Done");
        }
    }
}
