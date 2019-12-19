/*
 Script for menu btns;
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuBtns : MonoBehaviour
{
    public int difficultyMode;
    public TMP_Text modeTxt;
    void Start()
    {
        difficultyMode = 1;
    }

    
    void Update()
    {
        
        if (difficultyMode == 1) {
            modeTxt.text = "EASY";
        }
        else if (difficultyMode == 2)
        {
            modeTxt.text = "MEDIUM";
        }
        else
        {
            modeTxt.text = "HARD";
        }

    }

    public void StartBtn() {
        FindObjectOfType<DifficultySrc>().difficulty = difficultyMode;
        SceneManager.LoadSceneAsync("Simulation");
    }

    public void QuitBtn() {
        Application.Quit();
    }

    public void ModeBtn() {
        if (difficultyMode < 3)
        {
            difficultyMode += 1;
        }
        else {
            difficultyMode = 1;
        }
    }
}
