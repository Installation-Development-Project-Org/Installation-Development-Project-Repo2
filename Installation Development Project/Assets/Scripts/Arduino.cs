using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using UnityEngine.UI;

public class Arduino : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("COM5", 9600); 
    Thread readThread = new Thread(ReadData);
    static bool checking = true;
    static public Text value;
    static int potVal = 0;
    // Start is called before the first frame update
    void Start()
    {
        value = GameObject.Find("ValueText").GetComponent<Text>();
        value.text = "Hello";
        OpenConnection();
        readThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = potVal.ToString();
    }

    private void OnApplicationQuit()
    {
        sp.Close();
        checking = false;
    }

    void OpenConnection()
    {
        sp.Open();
        sp.ReadTimeout = 5000;
        print("Opening port");
    }

    public static void ReadData()
    {
        while (checking)
        {
            try
            {
                string message = sp.ReadLine();
                potVal = int.Parse(message);
            }
            catch
            {
                print("Caught Error!");
            }
        }
    }

    public void SendData(string data)
    {
        sp.Write(data);
        print(data);
    }
}
