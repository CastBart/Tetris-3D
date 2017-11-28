using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderScrip : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(tag == "Music Slider")
            GetComponent<Slider>().value = musicVolume.musicVol;
        if (tag == "SFX Slider")
            GetComponent<Slider>().value = musicVolume.sfxVol;
    }
	
	// Update is called once per frame
	void Update () {
        if (tag == "Music Slider")
            musicVolume.musicVol = GetComponent<Slider>().value;
        if (tag == "SFX Slider")
            musicVolume.sfxVol = GetComponent<Slider>().value;
    }
}
