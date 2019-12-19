/*
 Scripts to control both the teams score
 */

using UnityEngine;
using UnityEngine.UI;

public class TeamScore : MonoBehaviour
{
    public int score;

    public Text scoreTxt;
    void Start()
    {
        score = 0;
    }

    
    void Update()
    {
        scoreTxt.text = score.ToString();   
    }
}
