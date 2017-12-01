using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    public static int score = 0;
    public Text scoreText;
    public static bool gameOver = false;

    public GameObject explosion;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update()
    {
        scoreText.text = "Score: " + score;
	}

    void deleteLine()
    {
        var temp = Grid.grid[Grid.m_i, Grid.m_y].gameObject.AddComponent<Rigidbody>();
        temp.AddForce(new Vector3(0,0, -5),ForceMode.Impulse);
        temp.gameObject.GetComponent<scaleDownBox>().SetScaleDown(true);
    }

    static public void popOffLine()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().deleteLine();
    }
    public void ScaleBlocks()
    {
        var objects = GameObject.FindGameObjectsWithTag("Block");

        foreach (GameObject block in objects)
        {
            var tempRB = block.AddComponent<Rigidbody>();
            tempRB.useGravity = true;
            tempRB.AddForce(new Vector3(0, 0, 0), ForceMode.Impulse);
        }
    }
}
