using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{
    public float scaleSpeed = 0.03f;
    const float maxScale = 1;
    public bool usingTNT;
     
	// Use this for initialization
	void Start ()
    {
        //Make our objects scale 0
        transform.localScale = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.localScale.x < maxScale)
        {
            //get the current scale of the object
            Vector3 currentScale = transform.localScale;

            transform.localScale = new Vector3(currentScale.x += scaleSpeed, currentScale.y += scaleSpeed, currentScale.z += scaleSpeed);

            //if our scale is gone past our max scale then set it to our max scale
            if (transform.localScale.x > 1)
            {
                transform.localScale = new Vector3(1, 1, 1);
                if (!usingTNT)
                {
                    GetComponent<Blocks>().scaled = true;
                }
            }
        }
	}
}
