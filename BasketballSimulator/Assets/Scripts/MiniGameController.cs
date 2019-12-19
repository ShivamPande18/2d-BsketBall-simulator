/*
 Script for contolling the choice methods
 */

using UnityEngine;


public class MiniGameController : MonoBehaviour
{
    public bool hasMiniGameStarted; 
    public bool GameEnded;

    public GameObject endPanel;   //game end panel
    public GameObject midChoice;  //pass tackle dribble
    public GameObject uEndChoice; //block
    public GameObject oEndChoice; //shoot






    void Start()
    {
        hasMiniGameStarted = false;
        GameEnded = false;
    }

    void Update()
    {
        if (!hasMiniGameStarted)
        {
            FindObjectOfType<Timer>().canInc = true;

            midChoice.SetActive(false);
            oEndChoice.SetActive(false);
            uEndChoice.SetActive(false);
        }
        else {
            //choice screen according to the position of the ball
            MakeChoice(FindObjectOfType<GamePlaySrc>().BallPos);
            FindObjectOfType<Timer>().canInc = false;
        }

        if (GameEnded)
        {
            FindObjectOfType<GamePlaySrc>().canSimulate = false;
            FindObjectOfType<GamePlaySrc>().canRunGame = false;
            FindObjectOfType<Timer>().canInc = false;
            endPanel.SetActive(true);
        }

    }

    

    void MakeChoice(int n)
    {
        if (n == 0)
        {
            uEndChoice.SetActive(true);
        }
        else if (n == 1 || n == 2 || n == 3)
        {
            midChoice.SetActive(true);
        }
        else {
            oEndChoice.SetActive(true);
        }
       
    }

    public void DribleClick()
    {
        if (FindObjectOfType<DefiningVars>().dribble >= FindObjectOfType<OppDefVars>().tackle && !FindObjectOfType<GamePlaySrc>().Towards_U) {

            FindObjectOfType<GamePlaySrc>().isTrue = true;
        }
        else
        {
            FindObjectOfType<GamePlaySrc>().isTrue = true;
        }

        hasMiniGameStarted = false;
        FindObjectOfType<GamePlaySrc>().canSimulate = true;
    }
    public void PassClick()
    {
        if(FindObjectOfType<DefiningVars>().passing >= FindObjectOfType<OppDefVars>().tackle && !FindObjectOfType<GamePlaySrc>().Towards_U) {

            FindObjectOfType<GamePlaySrc>().isTrue = true;
        }
        else
        {
            FindObjectOfType<GamePlaySrc>().isTrue = false;
        }
        hasMiniGameStarted = false;
        FindObjectOfType<GamePlaySrc>().canSimulate = true;
    }
    public void TackleClick()
    {
        if (FindObjectOfType<DefiningVars>().tackle >= FindObjectOfType<OppDefVars>().dribble && FindObjectOfType<GamePlaySrc>().Towards_U)
        {

            FindObjectOfType<GamePlaySrc>().isTrue = true;
        }
        else
        {
            FindObjectOfType<GamePlaySrc>().isTrue = false;
        }
        hasMiniGameStarted = false;
        FindObjectOfType<GamePlaySrc>().canSimulate = true;
    }

    public void ShootClick()
    {
        if (FindObjectOfType<DefiningVars>().shoot < FindObjectOfType<OppDefVars>().block)
        {
            FindObjectOfType<GamePlaySrc>().isTrue = false;
        }
        else
        {
            FindObjectOfType<GamePlaySrc>().isTrue = true;
        }
        hasMiniGameStarted = false;
        FindObjectOfType<GamePlaySrc>().canSimulate = true;
    }
    public void BlockClick()
    {
        if (FindObjectOfType<DefiningVars>().block < FindObjectOfType<OppDefVars>().shoot)
        {

            FindObjectOfType<GamePlaySrc>().isTrue = false;
        }
        else
        {
            FindObjectOfType<GamePlaySrc>().isTrue = true;
        }
        hasMiniGameStarted = false;
        FindObjectOfType<GamePlaySrc>().canSimulate = true;
    }

}
