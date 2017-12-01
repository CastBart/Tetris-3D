using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* @Author: Bartosz Zych
 * @Version: 1.0
 * @Start: 17/11/2017
 * @Description: Simple script that creates a new block when create block is called
 */
public class BlockCreator : MonoBehaviour {


    public GameObject[] blocks;

    GameObject displayVersion;
    
	// Use this for initialization
	void Start ()
    {
        //Grid.next = Random.Range(0, blocks.Length);
        Grid.next = 0;
        createBlock();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    /// <summary>
    /// Create a random block in that is stored in the blocks array
    /// </summary>
    public void createBlock()
    {
        //create the new block that moves down
        Instantiate(blocks[Grid.next], transform.position, Quaternion.identity);



       // Grid.next = Random.Range(0, blocks.Length);
        Grid.next = 0;
        //destroy the old display block
        Destroy(displayVersion);
        //create the display block(next block)
        displayVersion = Instantiate(blocks[Grid.next], new Vector3(-7.5f, 5, 0), Quaternion.identity);
        //disable scripts for movement
        displayVersion.GetComponent<Blocks>().enabled = false;
    }
   
    
}
