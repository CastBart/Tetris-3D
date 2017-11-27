using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void playbtn(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }
    public void exit()
    {
        Application.Quit();
    }
}
