/*
 This is the script for adjusting the simulation speed into 3 speeds
 */
using UnityEngine;
using TMPro;

public class CurPlaySrc : MonoBehaviour
{
    public int currentPlay;

    public TMP_Text currentPlayText;

    void Start()
    {
        currentPlay = 1;   
    }

    void Update()
    {

        /*
         1 for  >   (1x)
         2 for  >>  (2x)
         3 for  >>> (3x)

         */
        if (currentPlay == 1)
        {
            currentPlayText.text = ">";
            FindObjectOfType<Timer>().simulationSpeed = 500;
            FindObjectOfType<GamePlaySrc>().waitSecs = 3;
        }
        else if (currentPlay == 2) {
           
            currentPlayText.text = ">>";
            FindObjectOfType<Timer>().simulationSpeed = 400;
            FindObjectOfType<GamePlaySrc>().waitSecs = 2;
        }
       else
        {
            currentPlayText.text = ">>>";
            FindObjectOfType<Timer>().simulationSpeed = 300;
            FindObjectOfType<GamePlaySrc>().waitSecs = 1;
        }

    }

    // onClick() event for button adjusting simulation speed
    public void OnBtnClick() {
        if (currentPlay <= 2)
        {
            currentPlay += 1;
        }
        else {
            currentPlay = 1;
        }
    }
}
