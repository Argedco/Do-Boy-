using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This allows us to use the scene loading function
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour {
    
    // Called when title button is clicked
    public void GoToTitle()
    {
        // Return to title scene
        SceneManager.LoadScene("Title");
    }


}
