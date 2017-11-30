using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    public static int score = 0;
    public static float time = 120;
    public Text scoreText;
    public GameObject explosion;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        scoreText.text = "Score: " + score;
        spawnExplosion();
	}

    public void spawnExplosion()
    {
        if (Grid.spawn)
        {
            //Material tempMat = Grid.grid[Grid.m_i, Grid.m_y].gameObject.GetComponent<Renderer>().material;
            // Instantiate
            GameObject tempObject = GameObject.FindGameObjectWithTag("hi");
           // tempObject.GetComponent<Renderer>().material = tempMat;
            Instantiate(explosion, Grid.grid[Grid.m_i, Grid.m_y].gameObject.transform.position, Quaternion.identity);
            Grid.spawn = false;
        }
    }
}
