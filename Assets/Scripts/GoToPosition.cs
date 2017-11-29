using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPosition : MonoBehaviour {

    public Transform[] children;
    Vector3[] desiredPositions;
    int currentIndex;

	// Use this for initialization
	void Start ()
    {
        //Creating our array and setting the desired positions of our canvas elements
        desiredPositions = new Vector3[4];
        desiredPositions[0] = new Vector3(200, 45, -57.5f);
        desiredPositions[1] = new Vector3(200, 0, -57.5f);
        desiredPositions[2] = new Vector3(200, -40, -57.5f);
        desiredPositions[3] = new Vector3(200, -80, -57.5f);

        //the current element we are moving
        currentIndex = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        children[currentIndex].transform.localPosition = Vector3.Lerp(children[currentIndex].transform.localPosition, desiredPositions[currentIndex], 0.1f);

        //If we have reached our desired position, disable this script
        if (Vector3.Distance(desiredPositions[currentIndex], children[currentIndex].transform.localPosition) <= 0.1f)
        {
            currentIndex++;

            //If we have gone past the bounds of our array then disable this script
            if(currentIndex >= 4)
                GetComponent<GoToPosition>().enabled = false;
        }

	}
}
