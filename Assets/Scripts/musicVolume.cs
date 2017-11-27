using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicVolume : MonoBehaviour {
    public AudioSource music;
	// Use this for initialization
	void Start () {
        music.GetComponent<AudioSource>();
        music.volume = PlayerPrefs.GetFloat("MusicVolumeLevel",0);
	}

}
