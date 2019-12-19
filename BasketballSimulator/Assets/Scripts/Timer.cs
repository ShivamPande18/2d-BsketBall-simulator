/*
 Script for the time control of the game
 */

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public int simulationSpeed;

    int _cnt;
    int _timer;

    public Text timerStr;

    public bool canInc = true;
    


    void Start()
    {
        _timer = 0;
        _cnt = 0;
        canInc = true;

    }

    // Update is called once per frame
    void Update()
    {
        //normal play
        if (canInc)
        {
            _cnt++;
        }
        else
        {
            _cnt = 0;
        }

        //breaks in between
        if (_timer == 12 || _timer == 24 || _timer == 36)
        {
            canInc = false;
            FindObjectOfType<GamePlaySrc>().isbreak = true;
        }

        //game ends
        if (_timer == 48)
        {
            StartCoroutine(EndGame());
        }

        //normal timer increase
        if (_cnt >= simulationSpeed)
        {
            _timer++;
            _cnt = 0;
        }
        timerStr.text = _timer.ToString();
        


    }

    //func for game ending
    IEnumerator EndGame() {
        canInc = false;
        FindObjectOfType<GamePlaySrc>().isbreak = true;
        FindObjectOfType<SimulationText>().endTxt();
        yield return new WaitForSeconds(1);
        FindObjectOfType<MiniGameController>().GameEnded = true;
    }

}
