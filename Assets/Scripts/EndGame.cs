using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public AudioSource gameOverSound;
    bool once;

    void Start()
    {
        once = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (GameControllerScript.gameOver == true)
        {
            //play game over sound once 
            if(once == false)
            {
                gameOverSound.Play();
                once = true;
            }
        }
        if (other.transform.parent.GetComponent<Blocks>().enabled == false)
        {
            //If the game is not over then end the game
            if (GameControllerScript.gameOver == false)
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().EndGame();
        }
    }
}
