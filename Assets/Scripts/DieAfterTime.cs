using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author Bartosz
 * Descrption: Destroy our bomb particle effect when it is completed
 */ 

public class DieAfterTime : MonoBehaviour {

    ParticleSystem ps;
	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!ps.IsAlive())
        {
            Destroy(gameObject);
        }
	}
}
