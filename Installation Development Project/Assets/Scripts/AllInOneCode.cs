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
    [SerializeField] Image image13;
    [SerializeField] Image image10;
    [SerializeField] Image image16;

    void Start()
    {
        OpenConnection();
        readThread.Start();
        cardAWasUsed = false;

        flashlight.SetActive(true);

        CongratsPanel.SetActive(false);

        image13.enabled = false;
        image10.enabled = false;
        image16.enabled = false;
    }

    void Update()
    {
        playerAndLightControls();
        lastGameActiavte();

        if (dataRFID != null)
        {
            PrintInputs();
        }
    }


    void lastGameActiavte()
    {
        if (dataRFID == " 10 76 EC 34") //B
        {
            print("card B");
            cardBWasUsed = true;
            image13.enabled = true;
        }
        if (cardBWasUsed == true && dataRFID == " 40 5F 8B 35") //A
        {
            print("card A");
            cardAWasUsed = true;
            image10.enabled = true;
        }
        if (cardAWasUsed == true && dataRFID == " E0 74 EC 34") //E
        {
            print("card E");
            image16.enabled = true;

            Invoke("ActivateCongratsPanel", 5f);
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


                int.TryParse(light, out lightInt);
                int.TryParse(distance, out distanceInt);
                print(distanceInt + " " + lightInt);
                break;
            }
        }
    }

    //LIGHT and MOVEMENT
    void playerAndLightControls()
    {
        //Flashlight
        if(lightInt > 50)
        {
            print("light On");
            LightOn();
        }
        else
        {
            LightOFf();
        }

        //Movement
        if (distanceInt < 10) 
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
    public void LightOn()
    {
        print("light On");
        flashlight.SetActive(true);
        flashlightOn = true;
    }

    public void LightOFf()
    {
        flashlight.SetActive(false);
        flashlightOn = false;
    }

    void ActivateCongratsPanel()
    {
        CongratsPanel.SetActive(true);
    }

}
