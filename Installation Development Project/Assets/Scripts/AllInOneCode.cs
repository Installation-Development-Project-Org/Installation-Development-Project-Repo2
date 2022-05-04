using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class AllInOneCode : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("COM6", 9600); // Change this to match your Arduino's COM Port.
    Thread readThread = new Thread(ReadData);
    static bool checking = true;
    static string dataRFID;
    public string scannerActivate;
    public string rfidActiavte;

    static public Text value;
    public GameObject pushObject;
    public GameObject pushObject2;

    bool cassetsE = false;
    bool cassetsD = false;
    bool cassetsC = false;

    string distance;
    string light;

    bool cardBWasUsed = false;
    bool cardAWasUsed = false;
    bool cardCWasUsed = false;

    void Start()
    {
        OpenConnection();
        readThread.Start();
        cardAWasUsed = false;
    }

    void Update()
    {
        casesetsList();
        if (dataRFID != null)
        {
            PrintInputs();
        }
    }

    void casesetsList()
    {
        if (dataRFID == " 80 93 94 35")
        {
            cassetsE = true;
        }
        if (dataRFID == " D0 D1 D8 34")
        {
            cassetsC = true;
        }
        if (dataRFID == " 60 6D 93 35")
        {
            cassetsD = true;
        }
        if (cassetsE == true && cassetsC == true && cassetsD == true)
        {
            //lastGameActiavte();
            SendDataActivateScanners();
            playerAndLightControls();
        }
    }

    void playerAndLightControls()
    {
        //Iasmina the player contols and light goes in here 
        SendDataEndGame(); // this will activate the last game 
        lastGameActiavte();
    }


    void lastGameActiavte()
    {
        if (dataRFID == " 10 76 EC 34")
        {
            Destroy(pushObject);
            cardBWasUsed = true;
        }
        if (cardBWasUsed == true && dataRFID == " 40 5F 8B 35")
        {
            Destroy(pushObject2);
            cardAWasUsed = true;
        }
        if (cardBWasUsed == true && cardAWasUsed == true && dataRFID == " 40 5F 8B 35")
        {
            Destroy(pushObject2);
            cardCWasUsed = true;
        }
        if (cardBWasUsed == true && cardAWasUsed == true && cardCWasUsed == true)
        {
            //Close application here
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
                //print(dataRFID + " " +dataRFID.Substring(2, 2));
            }
            catch
            {
                //print("Caught Error!"); 
            }
        }
    }

    void PrintInputs()
    {
        for (int i = 0; i <= dataRFID.Length; i++)
        {
            if (dataRFID[i] == ' ')
            {
                distance = dataRFID.Substring(0, i);
                light = dataRFID.Substring(i, dataRFID.Length - i);

                print(distance + " " + light);
                break;
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

    public void SendDataActivateScanners()
    {
        sp.Write(scannerActivate);
        print(scannerActivate);
    }
    public void SendDataEndGame()
    {
        sp.Write(rfidActiavte);
        print(rfidActiavte);
    }
}
