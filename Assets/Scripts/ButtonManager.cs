using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static bool paused = false;
    public Text pauseText;
    public Button pauseBtn;
    public Button restartBtn;
    public Button exitBtn;

    void Start()
    {
        paused = false;

        //if our timescale is not 1 then reset it
        if (Time.timeScale != 1)
            Time.timeScale = 1;
    }
    public void SwitchScene(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }
    public void Restart()
    {
        paused = false;
        SceneManager.LoadScene("main"); //loads the scene called 'main'
    }
    public void PauseGame()
    {
        paused = !paused; //negate our bool

        //If paused is true then set the text of our pause button to continue and our timescale to 0
        if (paused == true)
        {
            Time.timeScale = 0;
            pauseText.text = "Continue";
        }
        //otherwise set it to pause and set teh timescale to 1
        else
        {

            pauseText.text = "Pause";
            Time.timeScale = 1;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    //Closes the game
    public void Exit()
    {
        Application.Quit();
    }
}
