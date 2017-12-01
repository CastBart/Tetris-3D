using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		if(scaleDown)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, scaleDesired, 0.05f);

            if (Vector3.Distance(transform.localScale, scaleDesired) <= 0.05f)
                Destroy(gameObject);
        }
	}

    public void SetScaleDown(bool scale)
    {
        scaleDown = scale;
    }
}
