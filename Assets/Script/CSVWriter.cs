using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    string filename = "";
    public bool playing;

    [System.Serializable]
    public class Gyro
    {
        public float x;

        public float y;

        public float z;
    }

    [System.Serializable]
    public class GyroList
    {
        public Gyro[] gyro;
    }

    public GyroList myGyroList = new GyroList();

    void Start()
    {
        filename = Application.dataPath + "/test.csv";

        TextWriter tw = new StreamWriter(filename, false);

        tw.WriteLine('Y');

        tw.Close();
    }

    void Update()
    {
        if(playing==true)
        {
            WriteCSV();
        }
    }

    void StartStop()
    {
        if(playing==true)
        {
            playing = false;
        }
        else if(playing==false)
        {
            playing = true;
        }
    }

    public void WriteCSV()
    {
        if (myGyroList.gyro.Length > 0)
        {
            TextWriter tw = new StreamWriter(filename, true);

            tw.Close();

            tw = new StreamWriter(filename, true);

            for (int i = 0; i < myGyroList.gyro.Length; i++)
            {
                myGyroList.gyro[i].y = Input.acceleration.y;
                tw.WriteLine(myGyroList.gyro[i].y);
            }
            tw.Close();

            Debug.Log("Splurge");
        }

    }
}
