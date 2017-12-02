using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Blocks : MonoBehaviour {
    public static float lastFall = 0;
    public bool scaled;
    public static float timeToFall;
    Scene scene;
    //time interval for down arrow (to be faster than right or left)
    float timeToNextMove;
    //same as above for right and left 
    float timeToNextMoveH;
    // time since last move
    float timeSinceLastMove;
    // Use this for initialization


    void Start ()
    {
        scaled = false;

        timeToNextMove = 0.05f;
        timeSinceLastMove = Time.time;

        timeToNextMoveH = 0.1f;
        scene = SceneManager.GetActiveScene();
        if (!validGrid())
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
       

    }
	
	// Update is called once per frame
	void Update () {
        if (scaled)
        {
            Debug.Log(Blocks.timeToFall);

             // Move Downwards and Fall
            if (Input.GetKey(KeyCode.DownArrow) ||
                     Time.time - lastFall >= timeToFall)

            {
                if (Time.time - timeSinceLastMove >= timeToNextMove)
                {
                    // Modify position
                    transform.position += new Vector3(0, -1, 0);

                    // See if valid
                    if (validGrid())
                    {
                        // It's valid. Update grid.
                        updateGrid();
                    }
                    else
                    {
                        // It's not valid. revert.
                        transform.position += new Vector3(0, 1, 0);

                        // Clear filled horizontal lines
                        Grid.deleteFullRows();

                        // Spawn next Group
                        FindObjectOfType<BlockCreator>().createBlock();

                        // Disable script
                        enabled = false;
                    }
                    lastFall = Time.time;
                    timeSinceLastMove = Time.time;
                }
            }
            // Move Left
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Time.time - timeSinceLastMove >= timeToNextMoveH)
                {
                    // Modify position
                    transform.position += new Vector3(-1, 0, 0);

                    // See if valid
                    if (validGrid())
                        // It's valid. Update grid.
                        updateGrid();
                    else
                        // It's not valid. revert.
                        transform.position += new Vector3(1, 0, 0);
                    timeSinceLastMove = Time.time;
                }
            }

            // Move Right
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Time.time - timeSinceLastMove >= timeToNextMoveH)
                {
                    // Modify position
                    transform.position += new Vector3(1, 0, 0);

                    // See if valid
                    if (validGrid())
                        // It's valid. Update grid.
                        updateGrid();
                    else
                        // It's not valid. revert.
                        transform.position += new Vector3(-1, 0, 0);
                    timeSinceLastMove = Time.time;
                }
            }

            // Rotate
            else if (Input.GetKeyDown(KeyCode.UpArrow) && tag != "O Block") //if we pressed the up arrow and this block is not an O Block
            {
                transform.Rotate(0, 0, -90);

                // See if valid
                if (validGrid())
                    // It's valid. Update grid.
                    updateGrid();
                else
                    // It's not valid. revert.
                    transform.Rotate(0, 0, 90);
            }  
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                //Infinite loop
                while(true)
                {
                    // Modify position
                    transform.position += new Vector3(0, -1, 0);

                    // See if valid
                    if (validGrid())
                    {
                        // It's valid. Update grid.
                        updateGrid();
                    }
                    else
                    {
                        // It's not valid. revert.
                        transform.position += new Vector3(0, 1, 0);

                        // Clear filled horizontal lines
                        Grid.deleteFullRows();

                        // Spawn next Group
                        FindObjectOfType<BlockCreator>().createBlock();

                        // Disable script
                        enabled = false;

                        break;
                    }
                }
            }
        }
    }

    bool validGrid()
    {
        foreach (Transform child in transform)
        {
            Vector3 v = Grid.roundVec3(child.position);
            if (!Grid.insideBorder(v))
                return false;

            if (Grid.grid[(int)v.x, (int)v.y] != null &&
                Grid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    void updateGrid()
    {
        for (int y = 0; y < Grid.height; ++y)
        {
            for (int x = 0; x < Grid.width; ++x)
            {
                if (Grid.grid[x, y] != null)
                {
                    if (Grid.grid[x, y].parent == transform)
                    {
                        Grid.grid[x, y] = null;
                    }
                }
            }
        }
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec3(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }
}
