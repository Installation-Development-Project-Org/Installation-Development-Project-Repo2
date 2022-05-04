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
    //public GameObject pushObject;
    //public GameObject pushObject2;

    bool cassetsE = false;
    bool cassetsD = false;
    bool cassetsC = false;

    string distance;
    string light;
    int lightInt;
    int distanceInt;

    bool cardBWasUsed = false;
    bool cardAWasUsed = false;
    bool cardCWasUsed = false;

    //Flashlight variables
    [SerializeField] GameObject flashlight;
    public bool flashlightOn;

    //Movement variables
    [SerializeField] PlayerMovement playerMovementScript;

    //CassetPlayer variables
    [SerializeField] CassetPlayer CassetPlayerScript;

    //UI
    [SerializeField] GameObject CongratsPanel;

    void Start()
    {
        OpenConnection();
        readThread.Start();
        cardAWasUsed = false;

        CongratsPanel.SetActive(false);
    }

    void Update()
    {
        //testInt();
        casesetsList();
        if (dataRFID != null)
        {
            PrintInputs();
        }
    }

    void casesetsList() //this needs to be separated because of the scene change
    {
        if (dataRFID == " 80 93 94 35")
        {
            cassetsE = true;
            CassetPlayerScript.PlayCasset16();
        }
        if (dataRFID == " D0 D1 D8 34")
        {
            cassetsC = true;
            CassetPlayerScript.PlayCasset10();
        }
        if (dataRFID == " 60 6D 93 35")
        {
            cassetsD = true;
            CassetPlayerScript.PlayCasset13();
        }
        if (cassetsE == true && cassetsC == true && cassetsD == true)
        {
            //lastGameActiavte();
            SendDataActivateScanners();
            playerAndLightControls();

            //CHANGE SCENE AFTER A DELAY 
            //Invoke("Timer", 15f);       //animation 4s + sound whatever seconds
            //Invoke("SwitchScene", 10f)  //however the timer is 

        }
    }

    void lastGameActiavte()
    {
        if (dataRFID == " 10 76 EC 34") //B
        {
            print("card B");
            cardBWasUsed = true;
        }
        if (cardBWasUsed == true && dataRFID == " 40 5F 8B 35") //A
        {
            print("card A");
            cardAWasUsed = true;
        }
        if (cardAWasUsed == true && dataRFID == " 40 5F 8B 35") //C
        {
            print("card C");
            //cardCWasUsed = true;

            CongratsPanel.SetActive(true);
        }
        /*
        if (cardBWasUsed == true && cardAWasUsed == true && cardCWasUsed == true)
        {
            //Close application here
        }*/
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


                int.TryParse(light, out lightInt);
                int.TryParse(distance, out distanceInt);
                print(distanceInt + " " + lightInt);
                //print(distance + " " + light);
                break;
            }
        }
    }

    //LIGHT and MOVEMENT
    void playerAndLightControls()
    {
        if (lightInt > 70) //CHANGE VALUE HERE
        {
            print("light On");
            flashlight.SetActive(true);
            flashlightOn = true;
        }
        else
        {
            flashlight.SetActive(false);
            flashlightOn = false;
        }

        if(distanceInt < 10) //CHANGE VALUE HERE
        {
            playerMovementScript.Move();
        }
        else
        {
            playerMovementScript.StopMoving();
        }

        SendDataEndGame(); // this will activate the last game 
        lastGameActiavte();
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
