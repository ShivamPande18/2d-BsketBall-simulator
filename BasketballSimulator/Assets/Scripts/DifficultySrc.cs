/*
 This script defines difficulty of game as selected in the menu and accordingly effects the opponent 
 team stats
 */

using UnityEngine;

public class DifficultySrc : MonoBehaviour
{
    public int difficulty;

    public GameObject thisObj;


    
    void Update()
    {
        DontDestroyOnLoad(thisObj);
    }
}
