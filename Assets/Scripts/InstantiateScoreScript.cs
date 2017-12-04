using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
/*
 * Author(s): Bart + Daryl
 * Descritption: Calculates the score just added when 1 or more lines is destroyed at once
 */


public class InstantiateScoreScript : MonoBehaviour {

    public GameObject scoreAdditionPrefab; //our prefab score addition object
	
	// Update is called once per frame
	void LateUpdate ()
    {
        //This adds to our score variable & gives a bonus on how many lines were just destroyed (each line gives an extra 60 points)
        if (Grid.tempScore > 0)
        {
            Grid.tempScore += Grid.lines * 60;
            createAddScore(Grid.tempScore);
           
            Grid.lines = 0;
            Grid.tempScore = 0;
        }
    }

    //Instantiates the prefab and updates our score string
    public void createAddScore(int score)
    {
        GameObject temp = Instantiate(scoreAdditionPrefab, transform);
        temp.GetComponent<Text>().text = "+" + score;
        GameControllerScript.score += score;
    }
}
