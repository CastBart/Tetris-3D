using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author Bartosz
 * Time - 6hrs
 */

public class TNTCreator : MonoBehaviour {

    public GameObject bomb;
    public AudioSource light;
    public AudioSource blow;
   
    bool alive = false;
    int randomSpawn = 0;
    float currentTime = 0;
    bool stopped = false;
   

	// Use this for initialization
	void Start () {
        light.volume = musicVolume.sfxVol;
        blow.volume = musicVolume.sfxVol;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if the blockstopped and is alive play the sound
        if (alive)
        { 
            if (stopped)
            {
                blow.Play();
               
                alive = false;
            }
       
        }
	}
    
    //instantiate a new bomb
    public void createTNT()
    {
        light.Play();
        randomSpawn = Random.Range((int)1,(int)10);
        Instantiate(bomb, new Vector3(randomSpawn, 15, 0), new Quaternion(0,90,0,0));
        alive = true;
        stopped = false;
       
    }
    public bool getAlive()
    {
        return alive;
    }
    public bool getStopped()
    {
        return stopped;
    }
    public void setStopped(bool newStopped)
    {
        currentTime = Time.time;
        stopped = newStopped;
    }


   
}
