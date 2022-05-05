using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using UnityEngine.SceneManagement;

public class RFID : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("COM6", 9600); 
    Thread readThread = new Thread(ReadData);
    static bool checking = true;
    static string dataRFID;

    //CassetPlayer variables
    [SerializeField] CassetPlayer CassetPlayerScript;

    static public Text value;

    public bool cardAWasUsed = false;
    public bool cardBWasUsed = false;

    bool cassetsE = false;
    bool cassetsD = false;
    bool cassetsC = false;

    public int coutdownTime;

    void Start()
    {
        OpenConnection();
        readThread.Start();
        cardAWasUsed = false;
    }

    void Update()
    {
        casesetsList();
    }
    void casesetsList() 
    {
        if (dataRFID == " 80 93 94 35")
        {
            cassetsE = true;
            CassetPlayerScript.PlayCasset16();
            print("E Done");
        }
        if (dataRFID == " D0 D1 D8 34")
        {
            cassetsC = true;
            CassetPlayerScript.PlayCasset10();
            print("C Done");
        }
        if (dataRFID == " 60 6D 93 35")
        {
            cassetsD = true;
            CassetPlayerScript.PlayCasset13();
            print("D Done");
        }
        if (cassetsE == true && cassetsC == true && cassetsD == true)
        {
            OnApplicationQuit();
            SceneManager.LoadScene("PickCardScene");
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

    /*IEnumerator CountDOwnTOSTart()
    {
        while (coutdownTime > 0)
        {
            coutdownDisplay.text = coutdownTime.ToString();

            yield return new WaitForSeconds(1f);

            coutdownTime--;
        }

        coutdownDisplay.text = "Game Over";
        print("CHangeSceme");

        coutdownDisplay.gameObject.SetActive(false);
    }*/
}
