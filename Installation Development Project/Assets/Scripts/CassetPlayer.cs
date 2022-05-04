using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassetPlayer : MonoBehaviour
{
    [SerializeField] public Animator anim16;
    [SerializeField] public Animator anim10;
    [SerializeField] public Animator anim13;


    void Start()
    {

    }

    /*  CASSET PLAYERS TEST
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)) //Light sensor thing is off
        {
            PlayCasset16();
        }
        if (Input.GetKey(KeyCode.W)) 
        {
            PlayCasset10();
        }
        if (Input.GetKey(KeyCode.E)) 
        {
            PlayCasset13();
        }
    }*/


    //16
    public void PlayCasset16()
    {
        gameObject.transform.position = new Vector3(55, 1.5f, 83);
        anim16.SetBool("PlayCasset", true);
        Invoke("PlayAudio16", 3f); //change this to align with the animation
    }

    void PlayAudio16()
    {
        //print("play audio");
        FindObjectOfType<SoundManager>().PlayAudio("16");
    }

    //10
    public void PlayCasset10()
    {
        gameObject.transform.position = new Vector3(65, 1.5f, 83);
        anim10.SetBool("PlayCasset", true);
        Invoke("PlayAudio10", 3f); //change this to align with the animation
    }

    void PlayAudio10()
    {
        //print("play audio");
        FindObjectOfType<SoundManager>().PlayAudio("10");
    }

    //13
    public void PlayCasset13()
    {
        gameObject.transform.position = new Vector3(75, 1.5f, 83);
        anim13.SetBool("PlayCasset", true);
        Invoke("PlayAudio13", 3f); //change this to align with the animation
    }

    void PlayAudio13()
    {
        //print("play audio");
        FindObjectOfType<SoundManager>().PlayAudio("13");
    }
}
