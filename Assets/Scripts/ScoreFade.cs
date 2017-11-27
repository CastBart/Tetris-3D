using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreFade : MonoBehaviour {

    Color textColor;
	// Use this for initialization
	void Start ()
    {
        textColor = GetComponent<Text>().color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (2 * Time.deltaTime), transform.position.z);


        textColor.a = textColor.a - 1.5f * Time.deltaTime;

        GetComponent<Text>().color = textColor;
    }
}
