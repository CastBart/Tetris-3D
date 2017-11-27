using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour {
    float lastFall = 0;
    // Use this for initialization
    public AudioSource moveBlockSound;
    public AudioSource rotateBlockSound;

    void Start () {
        if (!validGrid())
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
       
        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveBlockSound.Stop();
            moveBlockSound.Play();
            // Modify position
            transform.position += new Vector3(-1, 0, 0);

            // See if valid
            if (validGrid())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(1, 0, 0);
        }

        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveBlockSound.Stop();
            moveBlockSound.Play();
            // Modify position
            transform.position += new Vector3(1, 0, 0);

            // See if valid
            if (validGrid())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
        }

        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotateBlockSound.Stop();
            rotateBlockSound.Play();
            transform.Rotate(0, 0, -90);

            // See if valid
            if (validGrid())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
        }

        // Move Downwards and Fall
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                 Time.time - lastFall >= 1)
        {
            moveBlockSound.Stop();
            moveBlockSound.Play();
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

        }
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    // Modify position
        //    transform.position += new Vector3(0, -0.1f, 0);

        //    // See if valid
        //    if (validGrid())
        //    {
        //        // It's valid. Update grid.
        //        updateGrid();
        //    }
        //    else
        //    {
        //        // It's not valid. revert.
        //        transform.position += new Vector3(0, 0.1f, 0);

        //        // Clear filled horizontal lines
        //        Grid.deleteFullRows();

        //        // Spawn next Group
        //        FindObjectOfType<BlockCreator>().createBlock();

        //        // Disable script
        //        enabled = false;
        //    }
        //    lastFall = Time.time;
        //}




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
