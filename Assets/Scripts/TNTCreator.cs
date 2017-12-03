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

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
       if(alive)
        {
           
            if(stopped && Time.time - currentTime >= randomExplosionTime)
            {
                ////////////////////////
                //-----Explosion------//
                ////////////////////////
                Destroy(m_tnt);
            }
        }
	}
    
    public void createTNT()
    {
        randomSpawn = Random.Range((int)1,(int)10);
        randomExplosionTime = Random.Range(1.0f, 2.5f);
        m_tnt = Instantiate(bomb, new Vector3(randomSpawn, 15, 0), Quaternion.identity);
        alive = true;
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
