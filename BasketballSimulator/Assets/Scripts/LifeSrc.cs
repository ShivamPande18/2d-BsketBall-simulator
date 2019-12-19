/*
 This script specifies the energy/life of a player which degrades on every wrong move and substitutes 
 him when no life left
 */

using UnityEngine;
using UnityEngine.UI;


public class LifeSrc : MonoBehaviour
{
    public float life;
    
    public Scrollbar healthBar;

    public bool isPlayerSubstituted;

    public Camera cam;

    public Color normalCol;
    public Color substitutedCol;

    int cnt;
    void Start()
    {
        life = 100;
        isPlayerSubstituted = false;
        cnt = 0;
        
    }

   
    void Update()
    {
        
        healthBar.value = life / 100;
        

        if (life <= 0) {
            isPlayerSubstituted = true;
        }

        if (!isPlayerSubstituted) {
            cam.backgroundColor = normalCol;
        }
        else
        {
            cam.backgroundColor = substitutedCol;
            cnt++;
            if (cnt == 100)
            {
                IncHealth();
                cnt = 0;
            }
        }
    }

    //increases health on substituting
    void  IncHealth() {
        

        life += 10;
        if (life == 100)
        {
            isPlayerSubstituted = false;
        }
    }
}
