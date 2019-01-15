using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Needed for working with text components
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    //text component used to display the highscores
    public List<Text> highScoreDisplays = new List<Text>();

    //Numerical Values for highscores
    private List<int> highScoreData = new List<int>();

	// Use this for initialization
	void Start () {

        //Load the high score data from the player prefs
        LoadHighScoreData();

        //Get our Current score from player prefs
        int currentScore = PlayerPrefs.GetInt("score", 0);

        //Check if we got a new high-score
        bool haveNewHighScore = IsNewHighScore(currentScore);
        if (haveNewHighScore == true)
        {
            //add new score to the data
            AddScoreToList(currentScore);

            //save updated data
            SaveHighScoreData();
        }
       

        //Update the visual display
        UpdateVisualDisplay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadHighScoreData()
    {
        for(int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //Using the loop index, get the name for our PlayerPrefs key
            string prefskey = "highScore" + i.ToString();

            //Use this key to get the high score values from PLayerPrefs
            int highScoreValue = PlayerPrefs.GetInt(prefskey, 0);

            //Store this score value in our internal data list
            highScoreData.Add(highScoreValue);
        }
    }

    private void UpdateVisualDisplay()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //Find the specific text and number and match them up.
            highScoreDisplays[i].text = highScoreData[i].ToString();
        }
    }

    private bool IsNewHighScore(int scoreToCheck)
    {

        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //checks if the given score is a new highscore
            if (scoreToCheck > highScoreData[i])
            {
                //Return that we DO have a highscore 
                return true;
            }

        }


        //Default false
        return false;

    }

    private void AddScoreToList(int newScore)
    {
        //Look through the highscores and find out where the new score fits
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //Is our score higher than the score we're checking in the list?
            if (newScore > highScoreData[i])
            {
                //Our score IS higher. SSince we're going from highest to lowest, the first time our score is higher, this is where it must go
                //Insert the new score into the list here
                highScoreData.Insert(i, newScore);

                //Trim the last item off the list
                highScoreData.RemoveAt(highScoreData.Count - 1);

                //We're done, we must exit early
                return;
            }
        }
    }


    private void SaveHighScoreData()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //Using the loop index, get the name for our PlayerPrefs key
            string prefskey = "highScore" + i.ToString();

            //Get the current high score entry from the data
            int highScoreEntry = highScoreData[i];

            //Save this data to the PlayerPrefs
            PlayerPrefs.SetInt(prefskey, highScoreEntry);
        }

        //Save the player prefs to disk
        PlayerPrefs.Save();
    }
}
