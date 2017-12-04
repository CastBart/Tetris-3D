using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author Bartosz
 * Description: Deletes all instances of clones if not used
 */ 
public class DeleteBlock : MonoBehaviour {




	
	
	// Update is called once per frame
	void Update ()
    {
        if (this.transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
