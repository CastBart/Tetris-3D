using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/*
 * Author Daryl
 * Description: Handles the main menu buttons, by moving them at certain times and into the correct positions
 */
public class MenuManager : MonoBehaviour
{
    public GameObject[] PreGamebuttons; //our pregame buttons (Level 1, Level 2)
    public Vector3[] startPositions; // the start positions of the ui elements
    public Vector3[] endPositions; //the positions our menu elements should be at when the game starts up
    public Vector3[] levelColours; //the colour sof our levels (blue + red)
    public Material bgMaterial; //the material on our background plane
    bool startLevel; //bool to hold whether to start the level or not
    Vector3 chosenLevelColour; //the colour of the chosen level
    string levelChosenName; //the name of the level chosen

    public GameObject[] mainMenubuttons;
    public Vector3[] initialisePositions;
    bool startOfMenu; //bool to hold wether the scene has just started or not
    int currentButton; //the currently indexed button

    void Start()
    {
        currentButton = 0;
        startOfMenu = true;
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(5, 5, -19.25f);
        //Set our background to orange at the start of the game
        bgMaterial.color = new Color(levelColours[2].x, levelColours[2].y, levelColours[2].z, 255);
        startLevel = false;
    }

    void Update()
    {
        if(startOfMenu)
        {
            //lerping the buttons position to the initialise position
            mainMenubuttons[currentButton].transform.localPosition = Vector3.Lerp(mainMenubuttons[currentButton].transform.localPosition, initialisePositions[currentButton], 0.275f);

            //if the distance of the buttons position from its initialise position is minimal, then increase the button we are moving
            if (Vector3.Distance(mainMenubuttons[currentButton].transform.localPosition, initialisePositions[currentButton]) <= 0.05f)
            {
                currentButton++;

                if(currentButton >= mainMenubuttons.Length)
                {
                    startOfMenu = false;
                }
            }

        }

        //If we start the level
        if(startLevel)
        {
            //Get the current colour of the background and lerp it to the colour of the level we have chosen, (so change our background colour to red or blue)
            var newColour = Vector3.Lerp(new Vector3(bgMaterial.color.r, bgMaterial.color.g, bgMaterial.color.b), chosenLevelColour, 0.05f);
            bgMaterial.color = new Color(newColour.x, newColour.y, newColour.z, 1);

            //If the distance between the two colours is minimal then change the scene
            if(Vector3.Distance(newColour, chosenLevelColour) <= 0.01f)
            {
                SceneManager.LoadScene(levelChosenName);
            }
        }
    }

    //This is called when we press the play button
    public void EnableLevelSelectButtons()
    {
        MoveButtons(endPositions);
    }

    //This is called when we are in the pregame screen and we press the back button
    public void DisableLevelSelectButtons()
    {
        MoveButtons(startPositions);

        var menuButtons = GameObject.FindGameObjectsWithTag("UI");

        foreach(GameObject child in menuButtons)
        {
            child.GetComponent<LerpToVector>().vectorDesired = new Vector3(1, 1, 1);
        }
    }

    // This sets our parameters to go to level 1
    public void GoToLevel1()
    {
        levelChosenName = "main"; //selecting level 1

        chosenLevelColour = levelColours[0]; //sets the chosen level colour to level 1's colour

        //Move our buttons out of view
        MoveButtons(startPositions);

        //Scale down our logo
        GameObject.Find("Logo").GetComponent<LerpToVector>().enabled = true;

        var cameraRef = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LerpToVector>();
        cameraRef.vectorDesired = new Vector3(1.85f, cameraRef.vectorDesired.y, cameraRef.vectorDesired.z);

        startLevel = true;
    }

    // This sets our parameters to go to level 2
    public void GoToLevel2()
    {
        levelChosenName = "level2"; //selecting level 2

        chosenLevelColour = levelColours[1]; //sets the chosen level colour to levels 2's colour

        //Move our buttons out of view
        MoveButtons(startPositions);

        //Scale down our logos
        GameObject.Find("Logo").GetComponent<LerpToVector>().enabled = true;

        var cameraRef = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LerpToVector>();
        cameraRef.vectorDesired = new Vector3(1.85f, cameraRef.vectorDesired.y, cameraRef.vectorDesired.z);

        startLevel = true;
    }

    //Simply moves our buttons to a location depending on the vector passed to the method
    public void MoveButtons(Vector3[] positions)
    {
        //Move all of our pregame buttons back to where they were
        for (int i = 0; i < PreGamebuttons.Length; i++)
        {
            PreGamebuttons[i].GetComponent<LerpToVector>().vectorDesired = positions[i];
        }
    }
}
