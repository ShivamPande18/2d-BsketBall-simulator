/*
 Script for the simulation text
 */

using UnityEngine;
using TMPro;



public class SimulationText : MonoBehaviour
{
    public TMP_Text simulationText;

    int _randomInt;

    private void Start()
    {
        simulationText.text = "";
        _randomInt = 1;
    }

    void Update()
    {
        _randomInt = Random.Range(1, 13);
    }

    //Game start Text 1
    public void start1Txt() {
        if (_randomInt % 3 == 0)
        {
            simulationText.text += "The Match Starts On A Very Auspisious Day, The Crowd Is Looking Fantastic...\n\n";
        }
        else if (_randomInt % 3 == 1)
        {
            simulationText.text += "A Great Day For The Game To Start The Sun Is Shining Brightly Above...\n\n";
        }
        else
        {
            simulationText.text += "Great Day Great Match Great Weather Great spirits All Over The Stadium...\n\n";
        }
       
    }

    //Game sStart text 2
    public void start2Txt() {
        if (_randomInt % 3 == 0)
        {
            simulationText.text += "Both The Teams Are Looking Great Today...\n\n";
        }
        else if (_randomInt % 3 == 1)
        {
            simulationText.text += "Both The Teams Are In Their Best Forms...\n\n";
        }
        else
        {
            simulationText.text += "Both The Teams Need To Work Very Hard To Get Through It...\n\n";
        }
    }

    //Game ending text
    public void endTxt() {
        if (_randomInt % 3 == 0)
        {
            simulationText.text += "And Here Its Is The End Of Today's Play...\n\n";
        }
        else if (_randomInt % 3 == 1)
        {
            simulationText.text += "Well Meet You Next Time Till Then Goodbye...\n\n";
        }
        else
        {
            simulationText.text += "Thats All For Todays Play Its The End Will Meet You Next Time...\n\n";
        }

    }
   
    //halftime txt
    public void halfTime()
    {
        simulationText.text += "And here comes the break time...\n\n";
    }

    //choice txt
    public void playTxt(string placeholder)
    {
        if (_randomInt % 3 == 0)
        {
            simulationText.text += "The Ball Is With Jordan playing for " + placeholder + "...\n\n";
        }
        else if (_randomInt % 3 == 1)
        {
            simulationText.text += "The Jordans Got The Ball And Are Moving For " + placeholder + "...\n\n";
        }
        else
        {
            simulationText.text += "The Balls Is In The Hands Of The Jordans " + placeholder + "...\n\n";
        }
    }

    //passing , startBall , defense
    public void miniPlayBwGameTxt(bool won)
    {
        if (won)
        {
            simulationText.text += "Very nice play by Jordan,they won the ball... \n\n ";
            
            simulationText.text += "Now Rockstars are moving for an attack...\n\n";
            
            Debug.Log("Very nice play won the ball... \n Now moving for an attack...\n");

        }
        else {
            simulationText.text += "Ohh they have lost the ball... \n\n";
            
            simulationText.text += "Now Rockstars are moving for the defense...\n\n";

            if (!FindObjectOfType<LifeSrc>().isPlayerSubstituted)
            {
                FindObjectOfType<LifeSrc>().life -= 10;
            }
            
            Debug.Log("Ohh lost the ball... \n Now moving for the defense...\n");

        }
    }

    //block and shoot
    public void miniPlayEndGameTxt(bool won, bool isBlock) {
        if (won)
        {
            //block
            if (isBlock)
            {
                simulationText.text += "Very nice play won the ball and saved a basket...\n\n";
                
                simulationText.text += "Now Rocstars are moving fast for an attack...\n\n"; 
                
                Debug.Log("Very nice play won the ball and saved a basket... \n Now moving for an attack...\n");

            }
            //shooting
            else
            {
                simulationText.text += "Fantastic play by Jordan and its a a fabulous basket...\n\n";
                
                Debug.Log("Very nice play and its a basket...\n");

            }

        }
        else {
            //block
            if (isBlock)
            {
                simulationText.text += "Oh they have lost it and it will cost them a basket...\n\n";
                
                Debug.Log("Oh lost it and it will cost them a basket...\n");
                if (!FindObjectOfType<LifeSrc>().isPlayerSubstituted)
                {
                    FindObjectOfType<LifeSrc>().life -= 10;
                }

            }
            //shooting
            else
            {
                simulationText.text += "Ohh they have lost the ball... \n";
                
                simulationText.text+= "Now Rocstars are moving for the defense...\n\n";
                
                Debug.Log("Ohh lost the ball... \n Now moving for the defense...\n");
                if (!FindObjectOfType<LifeSrc>().isPlayerSubstituted)
                {
                    FindObjectOfType<LifeSrc>().life -= 10;
                }
            }
           

                
        }

        
    }

  
    
}
