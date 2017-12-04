using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author Daryl
 * Description: This script is used to make the camera move to the position: gamePos during the game. This position
 * is set elsewhere (in the button manager)
 */
public class CameraScript : MonoBehaviour {

    Vector3 pausedPos; //the position our camera should go to when paused
    Vector3 gamePos; //the position our camera should be when the game is ongoing

	// Use this for initialization
	void Start ()
    {
        gamePos = transform.position; //set the gamePos the current position of the camera
        pausedPos = new Vector3(17, 3.85f, -8.15f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(ButtonManager.paused) //if our game is paused, move our camera into position to show the pause menu
        {
            //if our cameras position is not the paused position
            if(transform.position != pausedPos)
            {
                transform.position = Vector3.Lerp(transform.position, pausedPos, 0.1f);
            }
        }
        else
        {
            if (transform.position != gamePos)
            {
                transform.position = Vector3.Lerp(transform.position, gamePos, 0.1f);
                if (Vector3.Distance(gamePos, transform.position) <= 0.01f)
                {
                    transform.position = gamePos;
                }
            }
        }
	}
}
