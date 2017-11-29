using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    public static int score = 0;
    public static float time = 120;
    public Text scoreText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        scoreText.text = "Score: " + score;
	}
}
