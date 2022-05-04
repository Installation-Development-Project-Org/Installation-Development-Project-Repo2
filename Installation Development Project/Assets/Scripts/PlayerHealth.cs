using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image heart1;
    [SerializeField] Image heart2;
    [SerializeField] Image heart3;
    [SerializeField] GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeLife()
    {
        if(heart3.enabled == true)
        {
            heart3.enabled = false;
        }
        else if (heart2.enabled == true)
        {
            heart2.enabled = false;
        }
        else if (heart1.enabled == true)
        {
            heart1.enabled = false;
        }
        
        if(heart3.enabled == false && heart2.enabled == false && heart1.enabled == false)
        {
            print("panel");
            GameOverPanel.SetActive(true);
        }
    }
}
