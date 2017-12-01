using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMusicVolume : MonoBehaviour {
    public AudioSource music;
    // Use this for initialization
    void Start () {
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
