using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class setMusicVolume : MonoBehaviour {
    public AudioSource music;
    Scene scene;
    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        if(scene.name == "level2")
        {
            music.pitch = 1.5f;
        }
        else
        {
            music.pitch = 1;
        }
        music.volume = musicVolume.musicVol;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameControllerScript.gameOver == true)
        {
            music.volume = 0;
        }
        else
            music.volume = musicVolume.musicVol;
    }
}
