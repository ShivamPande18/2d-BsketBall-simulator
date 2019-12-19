/*
 Script for the opponent team stats
 */

using UnityEngine;

public class OppDefVars : MonoBehaviour
{
    
    public int dribble;     //Choice in mid
    public int tackle;      //
   
    public int shoot;        //Choice at opp end

    public int block;       //choice at ur end


    private void Update()
    {
        if (FindObjectOfType<DifficultySrc>().difficulty == 1)
        {
            dribble = 30;
            tackle  = 40;
            shoot   = 30;
            block   = 40;
        }
        else if (FindObjectOfType<DifficultySrc>().difficulty == 1)
        {
            dribble = 40;
            tackle  = 50;
            shoot   = 40;
            block   = 60;
        }
        else
        {
            dribble = 60;
            tackle  = 70;
            shoot   = 60;
            block   = 50;
        }



    }



}
