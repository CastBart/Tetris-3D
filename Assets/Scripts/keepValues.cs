using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class keepValues : MonoBehaviour
{
    float musicVol;
    float sfxVol;
    public Slider music;
    public Slider sfx;
    void Awake()
    {
        DontDestroyOnLoad(music);

    }


    void Update()
    {
        musicVol = music.value;
        sfxVol = sfx.value;
    }
    void SaveSliderValue()
    {
        PlayerPrefs.SetFloat("MusicVolumeLevel", musicVol);
        PlayerPrefs.SetFloat("sfxVolumeLevel", sfxVol);
    }

}
