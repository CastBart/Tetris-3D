using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author Daryl
 * Description: This script is used to scale down any boxes that have this script attached to it when the game is over.
 */
public class scaleDownBox : MonoBehaviour {

    bool scaleDown;
    Vector3 scaleDesired;

	// Use this for initialization
	void Start () {
        scaleDown = false;
        scaleDesired = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //If our bool is true or th egame is over, then scale down our gameobject
		if(scaleDown || GameControllerScript.gameOver)
        {
            //Lerps our localscale
            transform.localScale = Vector3.Lerp(transform.localScale, scaleDesired, 0.1f);

            if (Vector3.Distance(transform.localScale, scaleDesired) <= 0.05f)
                Destroy(gameObject);
        }
	}

    public void SetScaleDown(bool scale)
    {
        scaleDown = scale;
    }
}
