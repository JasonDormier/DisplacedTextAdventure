using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AreaNavigation : MonoBehaviour {

    public GameArea currentArea;

    Dictionary<string, GameArea> exitDictionary = new Dictionary<string, GameArea>();
    private Controller controller;

    // Use this for initialization
    void Awake () {

        controller = GetComponent<Controller>();
		
	}

    public void SetupAreaExits()
    {
        //checking to see how many exits are in the room by looping through the exits in the array
        for (int i = 0; i < currentArea.exits.Length; i++)
        {

            exitDictionary.Add(currentArea.exits[i].keyString, currentArea.exits[i].nextArea);
            controller.areaInteractionDescription.Add(currentArea.exits[i].exitDescription);
        }
    }

    //checking to see if the player enters the correct key pharse to move onto the next area.
    public void TryToChangeAreas(string directionNoun) {

        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentArea = exitDictionary[directionNoun];
            controller.LogWithEnter("You head off to the " + directionNoun);
            controller.DisplayStoryAreaText();
        }
        else
        {

            controller.LogWithEnter(" There is no path to the " + directionNoun);

        }
    }

    public void ResetExits()
    {
        exitDictionary.Clear();
    }

	
}
