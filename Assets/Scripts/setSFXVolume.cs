using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author David
 * Description: Sets volume of sound effects depending on slider
 */ 
public class setSFXVolume : MonoBehaviour
{
    public AudioSource sfx;
    // Use this for initialization
    void Start()
    {
        sfx.volume = musicVolume.sfxVol;
    }

    // Update is called once per frame
    void Update()
    {
        sfx.volume = musicVolume.sfxVol;
    }
}
