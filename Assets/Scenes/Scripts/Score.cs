using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // Variable to track the visible text score
    //      Public to let us drag and drop in the editor
    public Text scoreText;

    // Variable to track the numerical score
    //      Private because other scripts should not 
    //          change it directly
    //      Default to 0 since we should not have any 
    //          score when starting
    private int numericalScore = 0;

	// Use this for initialization
	void Start () {
        // Get the score from the prefs database
        // Use a default of 0 of no score was saved
        // Store the result in our numerical score variable
        numericalScore = PlayerPrefs.GetInt("score", 0);

        // Update the visual score
        scoreText.text = numericalScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Function to increase the score
    //      Public so other scripts can use it (such as the coin)
    public void AddScore(int _toAdd)
    {
        // Add the amount to the numerical score
        numericalScore = numericalScore + _toAdd;

        // Update the visual score
        scoreText.text = numericalScore.ToString();
    }

    // Function to save the score to the player preferences
    //      Public so it can be triggered from another script (aka door)
    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", numericalScore);
    }
}
