using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This allows us to use the scene loading function
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    // This will be called by the Button component 
    // when the buton is clicked
    public void StartGame()
    {
        // Reset the score
        PlayerPrefs.DeleteKey("score");

        //Reset Lives
        PlayerPrefs.DeleteKey("lives");


        // Load the first level
        SceneManager.LoadScene("Level1");
    }

}
