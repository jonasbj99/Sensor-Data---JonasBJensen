using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    Gyroscope m_Gyro;
    bool ifButtonPressed = false;
    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    private void Update()
    {
        //Checks if the gyroscope is recording data. when button is pressed it is set to true
        if (ifButtonPressed)
        {
            Debug.Log(m_Gyro.attitude);
        }
    }
    public void setButtonPressed()
    {
        ifButtonPressed = !ifButtonPressed;
    }
    void OnGUI()
    {
        //Output the rotation rate, attitude and the enabled state of the gyroscope as a Label
        GUI.Label(new Rect(375, 300, 200, 40), "Gyro rotation rate " + m_Gyro.rotationRate);
        GUI.Label(new Rect(375, 350, 200, 40), "Gyro attitude" + m_Gyro.attitude);
        GUI.Label(new Rect(375, 400, 200, 40), "Gyro enabled : " + m_Gyro.enabled);
    }
}

