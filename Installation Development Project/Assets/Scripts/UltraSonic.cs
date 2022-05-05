using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using UnityEngine.UI;

public class UltraSonic : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("COM5", 9600); 
    public int message2;
    private float updtePeriod = 0.0f;
    public GameObject pushObject;

    void Start()
    {
        OpenConnection();
    }

    void Update() 
    {
        updtePeriod += Time.deltaTime;
        if (updtePeriod > 0.2f)
        {
            message2 = sp.ReadByte();
            print(message2);
            Vector3 temp = pushObject.transform.position;
            temp.z = (155.0f - message2) / 10.0f;
            pushObject.transform.position = temp;
            updtePeriod = 0.0f;
        }
    }

    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
            }
            else
            {
                sp.Open();
                sp.ReadTimeout = 1000;
            }
        }
        else
        {
            if (sp.IsOpen)
            {
                print("port is already open");
            }
            else
            {
                print("port == null");
            }
        }
    }

    void OnApplicationQuit()
    {
        sp.Close();
    }
}
