using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //pause bool called anywhere
    public static bool paused = false;
    //game buttons and pause text
    public Text pauseText;
    public Button pauseBtn;
    public Button restartBtn;
    public Button exitBtn;

    void Start()
    {
        //we are not paused initially 
        paused = false;

        //if our timescale is not 1 then reset it
        if (Time.timeScale != 1)
            Time.timeScale = 1;
    }
    //switches the scene to the scene passed in
    public void SwitchScene(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }
    //reloads the scene
    public void Restart()
    {
        paused = false;
        SceneManager.LoadScene("main"); //loads the scene called 'main'
        GameControllerScript.score = 0;
        GameControllerScript.gameOver = false;
    }
    //pauses the game
    public void PauseGame()
    {
        if (GameObject.FindGameObjectWithTag("BlockCreator").GetComponent<BlockCreator>().enabled)
        {
            paused = !paused; //negate our bool

            //If paused is true then set the text of our pause button to continue and our timescale to 0
            if (paused == true)
            {
                Time.timeScale = 0;
                pauseText.text = "Continue";
            }
            //otherwise set it to pause and set the timescale to 1
            else
            {

                pauseText.text = "Pause";
                Time.timeScale = 1;
            }
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void PreGame()
    {
        //if this method is called then set all the game objects in the main menus script to enables
        var objectList = GameObject.FindGameObjectsWithTag("UI");

        //enable the lerp script on all UI objects
        foreach(GameObject child in objectList)
        {
            //if the ui elemnt is active in the scene then enable their script
            if (child.activeInHierarchy)
                child.GetComponent<LerpToVector>().enabled = true;

            //else activate them
            else
                child.SetActive(true);
        }
    }

    //Closes the game
    public void Exit()
    {
        Application.Quit();
    }
}
