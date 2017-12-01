using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.transform.parent.GetComponent<Blocks>().enabled == false)
        {
            if(GameControllerScript.gameOver == false)
             GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().ScaleBlocks();

            GameControllerScript.gameOver = true;
            Debug.Log("HERE");
        }
    }
}
