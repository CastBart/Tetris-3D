using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* @Author Bartosz Zych
 * @Verion 1.0
 * @Start 17/11/2017
 * @Description: Helper script that will manage the following:
 *      - Delete a complete row
 *      - Move the above row down if one was deleted
 *      - Tell if a row is full
 *      - Delete multiple rows
 */ 
public class Grid : MonoBehaviour {


    public static int width = 10;
    public static bool spawn = false;
    public static int m_i = 0;
    public static int m_y = 0;
    public static int next = 0;
    public static int lines = 0;
    public static int level = 1;
    public static int height = 20;
    public static int tempScore = 0;
    public static List<GameObject> allBlocks = new List<GameObject>();
    public static Transform[,] grid = new Transform[width, height];
    public GameObject test;
    public GameObject particle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static Vector3 roundVec3(Vector3 v)
    {
        return new Vector3(Mathf.Round(v.x), Mathf.Round(v.y), Mathf.Round(v.z));
    }

    /// <summary>
    /// See if a blocks position is within the grid
    /// </summary>
    /// <param name="pos">position of a block</param>
    /// <returns></returns>
    public static bool insideBorder(Vector3 pos)
    {
        return ( ((int)pos.x >=0) && ((int)pos.x < width) && ((int)pos.y >=0) );
    }

    /// <summary>
    /// delete a row with the grids y
    /// </summary>
    /// <param name="y">value of the grids y</param>
    public static void deleteRow(int y)
    {
        for(int i = 0; i < width; i++)
        {
            spawn = true;
            m_i = i;
            m_y = y;
            Destroy(grid[i, y].gameObject);
            grid[i, y] = null;
        }
    }

    /// <summary>
    /// Delete row at y value
    /// </summary>
    /// <param name="y"></param>
    public static void decreaseRow(int y)
    {
        for (int i = 0; i < width; i++)
        {
            if (grid[i, y] != null)
            {

                grid[i, y - 1] = grid[i, y];
                grid[i, y] = null;
                grid[i, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    /// <summary>
    /// Move all rows down when a row was deleted
    /// </summary>
    /// <param name="y"></param>
    public static void decreaseRowsAbove(int y)
    {
        for (int i = y; i < height; ++i)
        {
            decreaseRow(i);
        }
    }

    /// <summary>
    /// Return a bool if a full row is complete
    /// </summary>
    /// <param name="y"></param>
    /// <returns></returns>
    public static bool isRowFull(int y)
    {
        for (int i = 0; i < width; ++i)
        {
            if (grid[i, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Function that determins is a row needs to be deleted or not 
    /// Uses all above functions as help
    /// </summary>
    public static void deleteFullRows()
    {
        for (int y = 0; y < height; ++y)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                decreaseRowsAbove(y + 1);
                --y;
                Grid.lines++;
                Grid.tempScore += 80;
                GameControllerScript.score += 80;
            }
        }
    }
}
