using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coiutdownCHnageSCene : MonoBehaviour
{
    public int coutdownTime;
    public Text coutdownDisplay;

    private void Start()
    {
        StartCoroutine(CountDOwnTOSTart());
    }

    IEnumerator CountDOwnTOSTart()
    {
        while (coutdownTime > 0)
        {
            coutdownDisplay.text = coutdownTime.ToString();

            yield return new WaitForSeconds(1f);

            coutdownTime--;
        }


        SceneManager.LoadScene("SampleScene");

        coutdownDisplay.gameObject.SetActive(false);
    }
}
