using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public Animator livesAnimator;
    public int startingLives = 5;
    private int numericalLives = 3;


    // Use this for initialization
    void Start () {
        //Retrieves the player's lives from playerprefs
        numericalLives = PlayerPrefs.GetInt("lives", startingLives);
        livesAnimator.SetInteger("Health", numericalLives);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoseLife()
    {
        //Updates the numerical Data
        numericalLives = numericalLives - 1;
        //Updates the actual text, by converting the number to a string.
        livesAnimator.SetInteger("Health", numericalLives);
    }

    public void SaveLives()
    {
        PlayerPrefs.SetInt("lives", numericalLives);
    }

    [ContextMenu("Reset Lives")]
    public void ResetLives()
    {
        PlayerPrefs.DeleteKey("lives");
    }

    public bool IsGameOver()
    {
        if (numericalLives <= 0) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
