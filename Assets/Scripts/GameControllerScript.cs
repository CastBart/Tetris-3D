using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    public static int score = 0;
    public Text scoreText;
    public Text levelText;
    public static int lines = 0;
    public Text linesText;

    public static bool gameOver = false;
    public AudioSource lineComplete;
    public GameObject explosion;

    public GameObject[] uiElements; //our canvas buttons
    public Vector3[] endGamePositions; //the positions of our ui at the end of the game

    public Material bgMaterial;
    public Color[] bgColours;

    //These booleans are used to restart the scene
    bool restartGame;
    bool goToMainMenu;
    float switchSceneTime;

    // Use this for initialization
    void Start ()
    {
        //Set our materials colour to the first colour in our colour array
        bgMaterial.color = bgColours[0];

        restartGame = false;
        goToMainMenu = false;
        switchSceneTime = 1.5f; //the time it takes to switch scene

        //Set game over to false
        GameControllerScript.gameOver = false;

        //reset our score at the start of every level
        GameControllerScript.score = 0;

        if (SceneManager.GetActiveScene().name == "level2")
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
        //if either boolean is true
        if (restartGame || goToMainMenu)
        {
            switchSceneTime -= Time.deltaTime; //decrement our time till we switch scenes

            //If we are going to the main menu, then change our materials colour for a smooth transition
            if(goToMainMenu)
            {
                bgMaterial.color = Vector4.Lerp(bgMaterial.color, bgColours[1], 0.0225f);
            }

            //If our timer has reached 0 then switch the scene depending on which bool is true
            if(switchSceneTime <= 0)
            {
                if(restartGame)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload the current scene
                }
                else if(goToMainMenu)
                {
                    SceneManager.LoadScene("menu"); //load the main menu scene
                }
            }
        }

        //else continue updating our blocks speed and score
        else
        {


            if (SceneManager.GetActiveScene().name == "level2")
            {
                //if the scene is level two make the blocks gradually pick up speed
                if (Blocks.timeToFall > 0.15)
                {
                    Blocks.timeToFall -= 0.0001f;
                }
                if (Blocks.timeToFall < 0.15)
                {
                    Blocks.timeToFall = 0.15f;
                }
            }
            scoreText.text = "Score: " + score;
        }
      
	}

    void deleteLine()
    {
        lineComplete.Stop();
        lineComplete.Play();
        var temp = Grid.grid[Grid.m_i, Grid.m_y].gameObject.AddComponent<Rigidbody>();
        temp.AddForce(new Vector3(0,0, -5),ForceMode.Impulse);
        temp.gameObject.GetComponent<scaleDownBox>().SetScaleDown(true);        
    }

    //This s called when we wanna delete a line of blocks
    static public void popOffLine()
    {
        //Since we cannot call non-static methods inside of here, we call the deleteLine method with the object that has this script
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().deleteLine();
    }

    //Ends the game by moving our buttons into the centre of the screen and displaying the score and different buttons
    public void EndGame()
    {
        GameControllerScript.gameOver = true;

        //For each element in our ui array array
        for (int i = 0; i < uiElements.Length; i++)
        {
            //enable and set our lerp script values
            uiElements[i].GetComponent<LerpToVector>().enabled = true;
            uiElements[i].GetComponent<LerpToVector>().vectorDesired = endGamePositions[i];
        }

        //Set our lerp values for our camera and disable the camera script on our camera
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LerpToVector>().vectorDesired = new Vector3(5, 5, -19.25f);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().enabled = false;
        //Scale down our particle system
        GameObject.Find("Particle System").GetComponent<LerpToVector>().enabled = true;
    }

    //Restarts the scene
    public void RestartGame()
    {
        if (GameObject.FindGameObjectWithTag("BlockCreator").GetComponent<BlockCreator>().enabled)
        {
            if (GameControllerScript.gameOver == false)
                EndGame();

            //Set our lerp values for our camera and disable the camera script on our camera
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LerpToVector>().vectorDesired = new Vector3(1.85f, 5, -19.25f);

            ClearScreen();

            restartGame = true;
        }
    }

    //Allows us to go to the main menu
    public void GoToMainMenu()
    {
        if (GameObject.FindGameObjectWithTag("BlockCreator").GetComponent<BlockCreator>().enabled)
        {
            if (GameControllerScript.gameOver == false)
                EndGame();

            ClearScreen();

            goToMainMenu = true;
        }
    }

    public void ClearScreen()
    {
        foreach (GameObject element in uiElements)
        {
            element.GetComponent<LerpToVector>().lerpLocal = true;
            element.GetComponent<LerpToVector>().lerpScale = true;
            element.GetComponent<LerpToVector>().lerpPosition = false;
            element.GetComponent<LerpToVector>().vectorDesired = new Vector3(0,0,0);
        }
    }
}
