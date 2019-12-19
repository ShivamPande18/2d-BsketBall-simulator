/*
 Script for managing the main text simulation 
 */

using System.Collections;
using UnityEngine;
using TMPro;


public class GamePlaySrc : MonoBehaviour
{

    public bool isTrue; //is choice successfull or not
    public bool canSimulate = false; //true after a choice is made
    public bool isbreak; //for halftimes
    public bool canRunGame; //contols the whole simulation if its runing or not
    public bool Towards_U; //direction of the ball

    bool _showBreakTxt; //break time texts
    bool _showStartTxt; //game start texts

    public int BallPos; //tells pos of ball from 0 = ur side to 4 = opponent side

    int _randomNum;

    public float waitSecs; //simulation speed

    public GameObject myTeam; 
    public GameObject opponentTeam;
    
    public TMP_Text finalScore;
    public TMP_Text result; 

   

    


    void Start()
    {
        _showBreakTxt = false;
        _showStartTxt = true;
        canRunGame = true;
        isbreak = false ;
        BallPos = 2;
        Towards_U = true;
    }


    void Update()
    {
        _randomNum = Random.Range(0,3);//for when the player is substituted


        //end score and result
        finalScore.text = myTeam.GetComponent<TeamScore>().score.ToString() + " - " + opponentTeam.GetComponent<TeamScore>().score.ToString();
        if (myTeam.GetComponent<TeamScore>().score > opponentTeam.GetComponent<TeamScore>().score)
        {
            result.text = "VICTORY";
        }
        else if (myTeam.GetComponent<TeamScore>().score < opponentTeam.GetComponent<TeamScore>().score)
        {
            result.text = "YOU LOST";
        }
        else
        {
            result.text = "DRAW";
        }
        //


        //For Breat Teme
        if (isbreak && _showBreakTxt)
        {
            Debug.Log("its half time...\n Press 'A' to start");//Press a to re continue game
            FindObjectOfType<SimulationText>().halfTime();
            _showBreakTxt = false;
            BallPos = 2;

        }
        //Press a to recontinue game
        if (Input.GetKeyDown(KeyCode.A) && isbreak)
        {
            isbreak = false;
            FindObjectOfType<Timer>().canInc = true;

        }


        //normal game loop call

        if (canRunGame && !isbreak)
        {

            StartCoroutine(gamePlayLoop());
            canRunGame = false;

        }
    }




    /////////////////////////////////////////////////// Game Loop////////////////////////////////////////////////////////


    // Main Game Loop
    // One block is explained rest works exactly the same
    IEnumerator gamePlayLoop()
    {

        _showBreakTxt = false;


        //When Ball Is At Your side
        if (BallPos == 0)
        {
            yield return new WaitForSeconds(waitSecs);
            // playing for ("block")
            FindObjectOfType<SimulationText>().playTxt("block");
            yield return new WaitForSeconds(waitSecs+1);

            // script when player is not substituted

            if (!FindObjectOfType<LifeSrc>().isPlayerSubstituted)
            {
                //choice to be made
                FindObjectOfType<MiniGameController>().hasMiniGameStarted = true;
                //by default the choice fails but will change when he chooses
                isTrue = false;

                //script will not procede until you make a choice
                yield return new WaitUntil(() => canSimulate == true);
                FindObjectOfType<MiniGameController>().hasMiniGameStarted = false;
            }
            //when the player is sunstituted
            else {
                
                if (_randomNum %2!= 0)
                {
                    isTrue = false;
                }
                else {
                    isTrue = true;
                }
            }

            yield return new WaitForSeconds(waitSecs);
            FindObjectOfType<SimulationText>().miniPlayEndGameTxt(isTrue, true);
            canSimulate = false;

            //opponent scores if your choice fails and ball is at your extreme side
            if (!isTrue)
            {
                opponentTeam.GetComponent<TeamScore>().score++;
            }


            Towards_U = false;
            BallPos += 1;
        }

        //When Ball Is At Your side pos = 1
        else if (BallPos == 1)
        {
            if (Towards_U)
            {
                yield return new WaitForSeconds(waitSecs);
                FindObjectOfType<SimulationText>().playTxt("tackle");
                yield return new WaitForSeconds(waitSecs+1);
                if (!FindObjectOfType<LifeSrc>().isPlayerSubstituted)
                {
                    FindObjectOfType<MiniGameController>().hasMiniGameStarted = true;


                    isTrue = false;
                    yield return new WaitUntil(() => canSimulate == true);
                    FindObjectOfType<MiniGameController>().hasMiniGameStarted = false;
                }
                else
                {
                    
                    if (_randomNum % 2 != 0)
                    {
                        isTrue = false;
                    }
                    else
                    {
                        isTrue = true;
                    }
                }
                
                yield return new WaitForSeconds(waitSecs);
                FindObjectOfType<SimulationText>().miniPlayBwGameTxt(isTrue);
                canSimulate = false;
                if (isTrue)
                {
                    BallPos += 1;
                    Towards_U = false;
                }
                else
                {
                    BallPos -= 1;
                    Towards_U = true;
                }
            }
            else
            {
                yield return new WaitForSeconds(waitSecs);
                FindObjectOfType<SimulationText>().playTxt("dribble");
                yield return new WaitForSeconds(waitSecs+1);
                if (!FindObjectOfType<LifeSrc>().isPlayerSubstituted)
                {
                    FindObjectOfType<MiniGameController>().hasMiniGameStarted = true;


                    isTrue = false;
                    yield return new WaitUntil(() => canSimulate == true);
                    FindObjectOfType<MiniGameController>().hasMiniGameStarted = false;
                }
                else
                {
                    
                    if (_randomNum % 2 != 0)
                    {
                        isTrue = false;
                    }
                    else
                    {
                        isTrue = true;
                    }
                }
                
                yield return new WaitForSeconds(waitSecs);
                FindObjectOfType<SimulationText>().miniPlayBwGameTxt(isTrue);
                canSimulate = false;
                if (isTrue)
                {
                    BallPos += 1;
                    Towards_U = false;
                }
                else
                {
                    BallPos -= 1;
                    Towards_U = true;
                }
            }



        }
        //When Ball Is At opponnent side pos = 3
        else if (BallPos == 3)
        {
            if (Towards_U)
            {
                yield return new WaitForSeconds(waitSecs);
                FindObjectOfType<SimulationText>().playTxt("tackle");
                yield return new WaitForSeconds(waitSecs+1);
                if (!FindObjectOfType<LifeSrc>().isPlayerSubstituted)
                {
                    FindObjectOfType<MiniGameController>().hasMiniGameStarted = true;


                    isTrue = false;
                    yield return new WaitUntil(() => canSimulate == true);
                    FindObjectOfType<MiniGameController>().hasMiniGameStarted = false;
                }
                else
                {
                    
                    if (_randomNum % 2 != 0)
                    {
                        isTrue = false;
                    }
                    else
                    {
                        isTrue = true;
                    }
                }
                
                yield return new WaitForSeconds(waitSecs);
                FindObjectOfType<SimulationText>().miniPlayBwGameTxt(isTrue);
                canSimulate = false;
            }
            else
            {
                yield return new WaitForSeconds(waitSecs);
                FindObjectOfType<SimulationText>().playTxt("dribble");
                yield return new WaitForSeconds(waitSecs+1);
                if (!FindObjectOfType<LifeSrc>().isPlayerSubstituted)
                {
                    FindObjectOfType<MiniGameController>().hasMiniGameStarted = true;


                    isTrue = false;
                    yield return new WaitUntil(() => canSimulate == true);
                    FindObjectOfType<MiniGameController>().hasMiniGameStarted = false;
                }
                else
                {
                   
                    if (_randomNum % 2 != 0)
                    {
                        isTrue = false;
                    }
                    else
                    {
                        isTrue = true;
                    }
                }
                
                yield return new WaitForSeconds(waitSecs);
                FindObjectOfType<SimulationText>().miniPlayBwGameTxt(isTrue);
                canSimulate = false;
            }
            if (isTrue)
            {
                BallPos += 1;
                Towards_U = false;
            }
            else
            {
                BallPos -= 1;
                Towards_U = true;
            }
        }

        //When Ball Is At mid
        else if (BallPos == 2 && !_showStartTxt)
        {
            if (Towards_U)
            {
                yield return new WaitForSeconds(waitSecs);
                FindObjectOfType<SimulationText>().playTxt("tackle");
                yield return new WaitForSeconds(waitSecs+1);
                if (!FindObjectOfType<LifeSrc>().isPlayerSubstituted)
                {
                    FindObjectOfType<MiniGameController>().hasMiniGameStarted = true;


                    isTrue = false;
                    yield return new WaitUntil(() => canSimulate == true);
                    FindObjectOfType<MiniGameController>().hasMiniGameStarted = false;
                }
                else
                {
                   
                    if (_randomNum % 2 != 0)
                    {
                        isTrue = false;
                    }
                    else
                    {
                        isTrue = true;
                    }
                }
                
                yield return new WaitForSeconds(waitSecs);
                FindObjectOfType<SimulationText>().miniPlayBwGameTxt(isTrue);
                canSimulate = false;
            }
            else
            {
                yield return new WaitForSeconds(waitSecs);
                FindObjectOfType<SimulationText>().playTxt("passing");
                yield return new WaitForSeconds(waitSecs+1);
                if (!FindObjectOfType<LifeSrc>().isPlayerSubstituted)
                {
                    FindObjectOfType<MiniGameController>().hasMiniGameStarted = true;


                    isTrue = false;
                    yield return new WaitUntil(() => canSimulate == true);
                    FindObjectOfType<MiniGameController>().hasMiniGameStarted = false;
                }
                else
                {
                    
                    if (_randomNum % 2 != 0)
                    {
                        isTrue = false;
                    }
                    else
                    {
                        isTrue = true;
                    }
                }
                
                yield return new WaitForSeconds(waitSecs);
                FindObjectOfType<SimulationText>().miniPlayBwGameTxt(isTrue);
                canSimulate = false;

            }
            if (isTrue)
            {
                BallPos += 1;
                Towards_U = false;
            }
            else
            {
                BallPos -= 1;
                Towards_U = true;
            }
        }

        //When Ball Is At opponent side

        else if (BallPos == 4)
        {
            yield return new WaitForSeconds(waitSecs);
            FindObjectOfType<SimulationText>().playTxt("shoot");
            yield return new WaitForSeconds(waitSecs+1);
            if (!FindObjectOfType<LifeSrc>().isPlayerSubstituted)
            {
                FindObjectOfType<MiniGameController>().hasMiniGameStarted = true;


                isTrue = false;
                yield return new WaitUntil(() => canSimulate == true);
                FindObjectOfType<MiniGameController>().hasMiniGameStarted = false;
            }
            else
            {
                
                if (_randomNum % 2 != 0)
                {
                    isTrue = false;
                }
                else
                {
                    isTrue = true;
                }
            }
            
            yield return new WaitForSeconds(waitSecs);
            FindObjectOfType<SimulationText>().miniPlayEndGameTxt(isTrue, false);
            canSimulate = false;
            Towards_U = true;
            if (isTrue)
            {
                myTeam.GetComponent<TeamScore>().score++;
            }
            BallPos -= 1;

        }
        else
        {
            Debug.Log("asdasda");
        }

        //block for the game at the start of the simulation..
        if (_showStartTxt)
        {
            _showStartTxt = false;
            yield return new WaitForSeconds(waitSecs);
            //start text 1st
            FindObjectOfType<SimulationText>().start1Txt();
            yield return new WaitForSeconds(waitSecs);

            //start text 2nd
            FindObjectOfType<SimulationText>().start2Txt();
            yield return new WaitForSeconds(waitSecs);
            FindObjectOfType<SimulationText>().playTxt("start ball");
            yield return new WaitForSeconds(waitSecs+1);
            if (!FindObjectOfType<LifeSrc>().isPlayerSubstituted)
            {
                FindObjectOfType<MiniGameController>().hasMiniGameStarted = true;


                isTrue = false;
                yield return new WaitUntil(() => canSimulate == true);
                FindObjectOfType<MiniGameController>().hasMiniGameStarted = false;
            }
            else
            {
                
                if (_randomNum % 2 != 0)
                {
                    isTrue = false;
                }
                else
                {
                    isTrue = true;
                }
            }
            
            yield return new WaitForSeconds(waitSecs);
            FindObjectOfType<SimulationText>().miniPlayBwGameTxt(isTrue);
            canSimulate = false;

            if (isTrue)
            {
                BallPos += 1;
                Towards_U = false;

            }
            else
            {
                BallPos -= 1;
                Towards_U = true;
            }
        }

        //makes the game running
        canRunGame = true;
        //just for the break text
        _showBreakTxt = true;
    }

    
}
