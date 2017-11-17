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
	// Use this for initialization
	void Start () {
        createBlock();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Create a random block in that is stored in the blocks array
    /// </summary>
    public void createBlock()
    {
        int i = Random.Range(0, blocks.Length);

        Instantiate(blocks[i], transform.position, Quaternion.identity);
    }
}
