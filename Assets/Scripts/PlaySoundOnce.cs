using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnce : MonoBehaviour
{
    float lastFall = 0;
    public AudioSource move;
    public AudioSource rotate;
    //script to play a sound once rather than once per block to be used on blocks in conjunction with blocks script
    void Start()
    {
        lastFall = Blocks.lastFall;
        move.volume = musicVolume.sfxVol;
        rotate.volume = musicVolume.sfxVol;
    }
    void Update()
    {

        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move.Stop();
            move.Play();
        }

        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            move.Stop();
            move.Play();
        }

        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow) && tag != "O Block") //if we pressed the up arrow and this block is not an O Block
        {
            rotate.Stop();
            rotate.Play();
        }

        // Move Downwards and Fall
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                 Time.time - lastFall >= 1)
        {
            move.Stop();
            move.Play();
            lastFall = Time.time;
        }
        lastFall = Blocks.lastFall;
    }
}
