using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    /*
     * Author: David
     * Description: This script will be attached to the end game box trigger to determine if the game is over or not
     */

    //When an object collides with our trigger box and the object is not moving (is set in the grid)
    //we call EndGame in the game controller script
    void OnTriggerStay(Collider other)
    { 
 
        if (other.tag != "TNTCreator" &&  other.transform.parent.GetComponent<Blocks>().enabled == false)
        {
            //If the game is not over then end the game
            if (GameControllerScript.gameOver == false)
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().EndGame();
        }
    }
}
