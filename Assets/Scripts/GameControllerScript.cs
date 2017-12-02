using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    public static int score = 0;
    public Text scoreText;
    public static bool gameOver = false;
    public AudioSource lineComplete;
    bool nowPlay = false;
    public GameObject explosion;
    Scene scene;

    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "level2")
        {
            Blocks.timeToFall = 0.5f;
        }
        else
        {
            Blocks.timeToFall = 1;
        }
    }
	
	// Update is called once per frame
	void Update()
    {
        
        if (scene.name == "level2")
        {
            //if the scene is level two make the blocks gradually pick up speed
            if (Blocks.timeToFall > 0.15)
            {
                Blocks.timeToFall -= 0.0001f;
            }
            if(Blocks.timeToFall < 0.15)
            {
                Blocks.timeToFall = 0.15f;
            }
        }
        scoreText.text = "Score: " + score;
	}

    void deleteLine()
    {
        lineComplete.Stop();
        lineComplete.Play();
        var temp = Grid.grid[Grid.m_i, Grid.m_y].gameObject.AddComponent<Rigidbody>();
        temp.AddForce(new Vector3(0,0, -5),ForceMode.Impulse);
        temp.gameObject.GetComponent<scaleDownBox>().SetScaleDown(true);        
    }

    static public void popOffLine()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().deleteLine();
    }
    //public void ScaleBlocks()
    //{
    //    var objects = GameObject.FindGameObjectsWithTag("Block");

    //    foreach (GameObject block in objects)
    //    {

    //    }
    //}
}
