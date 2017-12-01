using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{

	// Use this for initialization
	void Awake ()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("music");
        if(music.Length> 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Scene scene = SceneManager.GetActiveScene();
		if(scene.name == "main")
        {
            Destroy(this.gameObject);
        }
	}
}
