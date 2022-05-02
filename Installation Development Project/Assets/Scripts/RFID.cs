using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class RFID : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("COM5", 9600); // Change this to match your Arduino's COM Port.
    Thread readThread = new Thread(ReadData);
    static bool checking = true;
    static string dataRFID;

    static public Text value;
    public GameObject pushObject;
    public GameObject pushObject2;

    public bool cardAWasUsed = false;

    void Start()
    {
        OpenConnection();
        readThread.Start();
        cardAWasUsed = false;
    }

    void Update()
    {
        TestDestroy();
    }

    void TestDestroy() //Iasmina Add and change things here  
    {
        if (dataRFID == " 40 5F 8B 35")
        {
            Destroy(pushObject);
            cardAWasUsed = true;
        }
        if (cardAWasUsed == true && dataRFID == " 10 76 EC 34")
        {
            Destroy(pushObject2);
        }
    }

    public static void ReadData()
    {
        while (checking)
        {
            try
            {
                string message = sp.ReadLine();
                dataRFID = message;

                dataRFID = dataRFID.Replace("\n", String.Empty);
                dataRFID = dataRFID.Replace("\r", String.Empty);
                dataRFID = dataRFID.Replace("\t", String.Empty);
                print(dataRFID);
            }
            catch
            {
                //print("Caught Error!");
            }
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
                sp.ReadTimeout = 5000;
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
