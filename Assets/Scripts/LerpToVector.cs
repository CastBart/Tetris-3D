using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple script that moves or scales an object to a desired vector
/// </summary>

public class LerpToVector : MonoBehaviour
{
    public Vector3 vectorDesired; //the position we want to go to
    public bool lerpScale; //to lerp the scale of this objects transform
    public bool lerpPosition; //to lerp the position of this objects transform
    public bool lerpLocal; //bool wheter to affect the world or local parameters of the object
    public float speed;


	// Update is called once per frame
	void Update ()
    {
        if (lerpScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, vectorDesired, speed);

            //if we have reached our destination and are off by 0.05f then just set our vector to the desired vector
            if (Vector3.Distance(transform.localScale, vectorDesired) <= 0.05f)
                transform.localScale = vectorDesired;
        }
        else if (lerpPosition)
        {
            if (lerpLocal)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, vectorDesired, speed);

                //if we have reached our destination and are off by 0.05f then just set our vector to the desired vector
                if (Vector3.Distance(transform.localPosition, vectorDesired) <= 0.05f)
                    transform.localPosition = vectorDesired;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, vectorDesired, speed);

                //if we have reached our destination and are off by 0.05f then just set our vector to the desired vector
                if (Vector3.Distance(transform.position, vectorDesired) <= 0.05f)
                    transform.position = vectorDesired;
            }
        }
	}
}
