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
	}

    void test()
    {
        var temp = Grid.grid[Grid.m_i, Grid.m_y].gameObject.AddComponent<Rigidbody>();
        temp.AddForce(new Vector3(0,0, -5),ForceMode.Impulse);
        temp.gameObject.GetComponent<scaleDownBox>().SetScaleDown(true);

        //Instantiate(explosion, Grid.grid[Grid.m_i, Grid.m_y].gameObject.transform.position,Quaternion.identity);
    }

    static public void popOffLine()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().test();
    }
}
