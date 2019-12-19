/*
 This is the script having all the vars necessary in the stats of user team
 */

using UnityEngine;

public class DefiningVars:MonoBehaviour
{
    
    public int dribble;   //Choice in mid
    public int passing;   //
    public int tackle;    //

    public int shoot;     //Choice at opp end

    public int block;     //Choice at ur end

    public int defence;   //Attack Vars
    public int attack;    //

    bool _isFirstTime;  /* True 
                        if playing game for first time else
                        else false
                        */



    private void Start()
    {
        //to check if player is playing the game first time or not
        if (PlayerPrefs.GetInt("isFirstTime") != 0)
        {
            _isFirstTime = false;
        }
        else
        {
            _isFirstTime = true;
        }

        //default stats if player is playing the game for the first time
        if (_isFirstTime)
        {
            block = tackle = passing = shoot = dribble = 50;

        }
        //stats change with game
        else
        {
            block = PlayerPrefs.GetInt("block");
            tackle = PlayerPrefs.GetInt("tackle");
            passing = PlayerPrefs.GetInt("passing");
            shoot = PlayerPrefs.GetInt("shoot");
            dribble = PlayerPrefs.GetInt("dribble");
        }


    }

    private void Update()
    {
        PlayerPrefs.SetInt("block", block);
        PlayerPrefs.SetInt("tackle", tackle);
        PlayerPrefs.SetInt("passing", passing);
        PlayerPrefs.SetInt("shoot", shoot);
        PlayerPrefs.SetInt("dribble", dribble);

       if (_isFirstTime) {
            PlayerPrefs.SetInt("isFirstTime",1);
            
        }





    }

}
