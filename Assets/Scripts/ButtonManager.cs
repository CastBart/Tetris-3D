using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    bool paused;
    public Text pauseText;
    void Start()
    {
        pauseText.GetComponent<Text>();
        paused = false;
        pauseText.enabled = false;
    }
    public void SwitchScene(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {
        paused = !paused;
        if (paused == true)
        {
            pauseText.enabled = true;
            Time.timeScale = 0;
        }
        else
        {
            pauseText.enabled = false;
            Time.timeScale = 1;
        }
    }
    public void exit()
    {
        Application.Quit();
    }
}
