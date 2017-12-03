﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPosition : MonoBehaviour {

    public Transform[] children;
    public Vector3[] desiredPositions;
    int currentIndex;

	// Use this for initialization
	void Start ()
    {
        //the current element we are moving
        currentIndex = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        children[currentIndex].transform.localPosition = Vector3.Lerp(children[currentIndex].transform.localPosition, desiredPositions[currentIndex], 0.1f);

        //If we have reached our desired position, disable this script
        if (Vector3.Distance(desiredPositions[currentIndex], children[currentIndex].transform.localPosition) <= 0.05f)
        {
            currentIndex++;

            //If we have gone past the bounds of our array then disable this script
            if(currentIndex >= desiredPositions.Length)
                GetComponent<GoToPosition>().enabled = false;
        }

	}
}
