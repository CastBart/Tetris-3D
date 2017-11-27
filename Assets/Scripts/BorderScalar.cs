﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScalar : MonoBehaviour {

    public GameObject blockCreator;
    Transform[] childTransforms;
    int[] processedTransforms;
    int currentProcessedIndex;
    int currentChild;
    float scaleSpeed;

    // Use this for initialization
    void Start ()
    {
        childTransforms = GetComponentsInChildren<Transform>();//gets a array of childTransforms

        currentChild = Random.Range(0, childTransforms.Length);//get a random index
        
        processedTransforms = new int[childTransforms.Length]; //create our processed transform array

        currentProcessedIndex = 0;
        scaleSpeed = 0.25f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        bool fullyScaled = true;

        //if the currently chosen child is not scale dup then scale them up
        if (childTransforms[currentChild].localScale.x < 1)
        {
            childTransforms[currentChild].localScale = new Vector3(childTransforms[currentChild].localScale.x + scaleSpeed, childTransforms[currentChild].localScale.y + scaleSpeed, childTransforms[currentChild].localScale.z + scaleSpeed);
        }
        else if(childTransforms[currentChild].localScale.x >= 1)
        {
            bool gotNewIndex = false;

            //Add the current child index to our processed array
            processedTransforms[currentProcessedIndex] = currentChild;

            currentProcessedIndex++; //increase our index

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

                if(foundValue == false)
                {
                    gotNewIndex = true;
                }
            }
        }

        foreach(Transform child in childTransforms)
        {
            if(child.localScale.x < 1)
            {
                fullyScaled = false;
            }
        }

        //If all boxes are scaled then disable this script
        if(fullyScaled)
        {
            blockCreator.GetComponent<BlockCreator>().enabled = true; //enable our block creator script
            GetComponent<BorderScalar>().enabled = false;
        }
	}
}