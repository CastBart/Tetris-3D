using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author Daryl
 * Description: This script is used to scale up the border of our game. We choose a random index in the array of border blocks and scale 
 * each one up. When all blocks are scaled we then start the game
 */
public class BorderScalar : MonoBehaviour {

    public GameObject blockCreator;
    public GameObject tntCreator;
    Transform[] childTransforms;
    int[] processedTransforms;
    int currentProcessedIndex;
    int currentChild;
    float scaleSpeed;
    Vector3 scaleDesired;
    float currentPercentage;
    public bool useTnt;

    // Use this for initialization
    void Start ()
    {
        childTransforms = GetComponentsInChildren<Transform>();//gets a array of childTransforms

        currentChild = Random.Range(0, childTransforms.Length);//get a random index
        
        processedTransforms = new int[childTransforms.Length]; //create our processed transform array

        currentProcessedIndex = 0;

        scaleSpeed = 22.5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.timeScale > 0)
        {
            bool fullyScaled = true;

            //if the currently chosen child is not scaled up then scale them up
            if (childTransforms[currentChild].localScale.x < 1)
            {
                childTransforms[currentChild].localScale = new Vector3(childTransforms[currentChild].localScale.x + scaleSpeed * Time.deltaTime, childTransforms[currentChild].localScale.y + scaleSpeed * Time.deltaTime, childTransforms[currentChild].localScale.z + scaleSpeed * Time.deltaTime);

                if(childTransforms[currentChild].localScale.x >= 1.0f)
                {
                    childTransforms[currentChild].localScale = new Vector3(1, 1, 1);
                }
            }
            else if (childTransforms[currentChild].localScale.x >= 1.0f)
            {
                bool gotNewIndex = false;

                //Add the current child index to our processed array
                processedTransforms[currentProcessedIndex] = currentChild;

                currentProcessedIndex++; //increase our index

                //Loop while we have not got a new index (block to scale)
                while (gotNewIndex == false)
                {
                    bool foundValue = false;

                    currentChild = Random.Range(0, childTransforms.Length); //get a new index for our children transforms

                    for (int i = 0; i < currentProcessedIndex; i++)
                    {
                        if (processedTransforms[i] == currentChild)
                        {
                            foundValue = true;
                        }
                    }

                    if (foundValue == false)
                    {
                        gotNewIndex = true;
                    }
                }
            }

            //If any children are not scaled then set our bool to false and break out
            foreach (Transform child in childTransforms)
            {
                if (child.localScale.x < 1)
                {
                    fullyScaled = false;
                    break;
                }
            }

            //If all boxes are scaled then disable this script
            if (fullyScaled)
            {
                blockCreator.GetComponent<BlockCreator>().enabled = true; //enable our block creator script

                if (useTnt) //if we are using tnt then enable this script
                {
                    FindObjectOfType<GameControllerScript>().GetComponent<TNTCreator>().enabled = true;
                }
                GetComponent<BorderScalar>().enabled = false;
            }
        }
	}
}
