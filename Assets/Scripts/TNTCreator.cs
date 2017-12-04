using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTCreator : MonoBehaviour {

    public GameObject bomb;
    GameObject m_tnt;
    bool alive = false;
    int randomSpawn = 0;
    float randomExplosionTime = 0;
    float currentTime = 0;
    bool stopped = false;
    bool destroy = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
       if(alive)
        {

            if (stopped)
            {
                destroy = true;
                alive = false;
            }
       
        }
	}
    
    public void createTNT()
    {
        randomSpawn = Random.Range((int)1,(int)10);
        randomExplosionTime = Random.Range(5.0f, 10.0f);
        m_tnt = Instantiate(bomb, new Vector3(randomSpawn, 15, 0), new Quaternion(0,90,0,0));
        alive = true;
        stopped = false;
        destroy = false;
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
