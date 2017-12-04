using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Blocks : MonoBehaviour {
    public static float lastFall = 0;
    public bool scaled;
    public static float timeToFall;
    bool useTNT;
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
        timeToNextMoveH = 0.15f;
        scene = SceneManager.GetActiveScene();
        if (!validGrid())
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "level2")
        {
            useTNT = true;
        }
        else
        {
            useTNT = false;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (scaled)
        {
            // Move Downwards and Fall
            if (Input.GetKey(KeyCode.DownArrow) ||
                     Time.time - lastFall >= timeToFall)
            {
                MoveDown();
            }
            // Move Left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }

            // Move Right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }

            // Rotate
            if (Input.GetKeyDown(KeyCode.UpArrow) && tag != "O Block") //if we pressed the up arrow and this block is not an O Block
            {
                Rotate();
            }
       
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MoveToBottom();
            }
        }
    
    }
    void MoveDown()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
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
                int random = Random.Range(1, 9);
                if (useTNT)
                {
                    if ((random == 8 || random == 7) && !FindObjectOfType<GameControllerScript>().GetComponent<TNTCreator>().getAlive())
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TNTCreator>().createTNT();
                        Debug.Log("Spawn");
                    }
                    else
                    {
                        FindObjectOfType<BlockCreator>().createBlock();
                    }
                }
                else
                {
                    FindObjectOfType<BlockCreator>().createBlock();
                }

                // Disable script
                enabled = false;
            }
            lastFall = Time.time;
            timeSinceLastMove = Time.time;
        }
    }
    void MoveLeft()
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
    void MoveRight()
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
    void MoveToBottom()
    {
        //Infinite loop
        while (true)
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
                int random = Random.Range(1, 9);
                if (useTNT)
                {
                    if ((random == 8 || random == 7) && !FindObjectOfType<GameControllerScript>().GetComponent<TNTCreator>().getAlive())
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TNTCreator>().createTNT();
                        Debug.Log("Spawn");
                    }
                    else
                    {
                        FindObjectOfType<BlockCreator>().createBlock();
                    }
                }
                else
                {
                    FindObjectOfType<BlockCreator>().createBlock();
                }


                // Disable script
                enabled = false;

                break;
            }
        }
    }
    void Rotate()
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
