using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTCreator : MonoBehaviour {

    public GameObject tnt;
    GameObject m_tnt;
    bool alive = false;
    int randomSpawn = 0;
    float randomExplosionTime = 0;

	// Use this for initialization
	void Start () {
       // createTNT();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
       
	}

    public void createTNT()
    {
        randomSpawn = Random.Range((int)1,(int)10);
        randomExplosionTime = Random.Range(1.0f, 2.5f);
        m_tnt = Instantiate(tnt, new Vector3(randomSpawn, 15, 0), new Quaternion(0,90,0,0));
        alive = true;
    }
    public bool getAlive()
    {
        return alive;
    }

}
