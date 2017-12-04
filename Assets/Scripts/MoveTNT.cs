using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/*
 * Author Bartek
 * Description: Moves The bomb down. The bomb stops when it reaches another block or hits the bottom of the grid
 */

public class MoveTNT : MonoBehaviour {

    // Use this for initialization
    public static float lastFall = 0;
    public bool scaled;
    public static float timeToFall;
    Scene scene;
    //time interval for down arrow (to be faster than right or left)
    float timeToNextMove;
    // time since last move
    float timeSinceLastMove;
    // Use this for initialization
    public GameObject explosion;
    bool destroy;
    bool move;

    void Start()
    {
        destroy = false;
        move = true;
       // scaled = false;

        timeToNextMove = 0.25f;
        timeSinceLastMove = Time.time;

        scene = SceneManager.GetActiveScene();
        if (!validGrid())
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
     
        Debug.Log(Blocks.timeToFall);

        // Move Downwards and Fall
        if (Time.time - lastFall >= timeToFall && move)

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

               
                    // Spawn next Group
                    FindObjectOfType<BlockCreator>().createBlock();


                    move = false;
                    FindObjectOfType<TNTCreator>().setStopped(true);
                    GetComponent<BoxCollider>().enabled = true;
                }
                lastFall = Time.time;
                timeSinceLastMove = Time.time;
            }
        }
        //destroy this object when this bool is true and instantiate a particle effect
        if(destroy)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    /// <summary>
    /// checks if a the next grid is valid
    /// </summary>
    /// <returns></returns>
    bool validGrid()
    {
        Vector3 v = Grid.roundVec3(transform.position);
        if (!Grid.insideBorder(v))
            return false;

        if (Grid.grid[(int)v.x, (int)v.y] != null && Grid.grid[(int)v.x, (int)v.y].parent != transform)
        {
            return false;
        }
            
        
        return true;
    }

  
    //updates grid 
    void updateGrid()
    {
        for (int y = 0; y < Grid.height; ++y)
        {
            for (int x = 0; x < Grid.width; ++x)
            {
                if (Grid.grid[x, y] != null)
                {
                    if (Grid.grid[x, y] == transform)
                    {
                        Grid.grid[x, y] = null;
                    }
                }
            }
        }
        Vector2 v = Grid.roundVec3(transform.position);
        Grid.grid[(int)v.x, (int)v.y] = transform;
      
    }

    /// <summary>
    /// destroy all block object that the tnt is collided with
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter(Collider collision)
    {

        Debug.Log("Destroy");
        Vector3 temp = collision.gameObject.transform.position;
        if(collision.tag == "Block")
        {
            Destroy(collision.gameObject);
        }

        destroy = true;
    }

}
