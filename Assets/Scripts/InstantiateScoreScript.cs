using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InstantiateScoreScript : MonoBehaviour {

    public GameObject test;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (Grid.tempScore > 0)
        {
            createAddScore(Grid.tempScore);
            Grid.tempScore = 0;
        }
    }

    public void createAddScore(int score)
    {
        GameObject temp = Instantiate(test, transform);
        temp.GetComponent<Text>().text = "+" + score;
    }
}
