using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicVolume : MonoBehaviour {
    //static values for the audio used anywhere
    public static float musicVol = 0.5f;
    public static float sfxVol = 0.5f;
   // public Slider musicVol;
	// Use this for initialization
	void Start () {

	}

    void OnLoadScene()
    {
        //getObjectWithTag("game Controller").getComponent<AudioSource>().volume = musicVolume.music.Vol;
    }
}
