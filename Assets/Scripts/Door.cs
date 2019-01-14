using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extra using statement to allow us to use the scene management functions
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    // Variable to let us save the score
    //      Public so we can drag and drop
    public Score scoreObject;

    // Designer variables
    public string sceneToLoad;

    // Unity calls this function automatically
    // when our spikes touch any other object
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Check if the thing that we collided with
        // is the player (aka has a Player script)
        Player playerScript = collision.collider.GetComponent<Player>();

        // Only do something if the thing we ran into
        // was in fact the player
        // aka playerScript is not null
        if (playerScript != null)
        {
            // We DID hit the player!

            // Save the score using our score object reference
            scoreObject.SaveScore();

            // Load the next level
            SceneManager.LoadScene(sceneToLoad);
        }
    }



}
