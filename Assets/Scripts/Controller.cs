using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour {

    //public Text dialogueText;
    public TextMeshProUGUI dialogueText;
    public InputAction[] inputActions;

    [HideInInspector] public AreaNavigation areaNavigation;
    [HideInInspector] public List<string> areaInteractionDescription = new List<string>();
    [HideInInspector] public InteractableItems interactableItems;

    //creating a new list
    List<string> storyLog = new List<string>();

    private void Awake()
    {
        interactableItems = GetComponent<InteractableItems>();
        areaNavigation = GetComponent<AreaNavigation>();

    }

    // Use this for initialization
    void Start () {

        //displaying the words to the screen when it loads. Without this the screen will be blank.
        DisplayStoryAreaText();
        //Displaying the actual story text to the screen
        DisplayText();
        
	}

    public void DisplayText()
    {

        string showText = string.Join("\n", storyLog.ToArray());

        //finally taking all the added strings and displaying them to the player.
        dialogueText.text = showText;

    }

    public void DisplayStoryAreaText()
    {
        ClearCache();

        StartArea();

        string combinedDescriptions = string.Join("\n", areaInteractionDescription.ToArray());

        string combinedText = areaNavigation.currentArea.description + "\n" + combinedDescriptions;

        LogWithEnter(combinedText);

    }

    private void StartArea()
    {
        areaNavigation.SetupAreaExits();
        PrepareObjectsToTakeOrExamine(areaNavigation.currentArea);
    }

    private void PrepareObjectsToTakeOrExamine(GameArea currentArea)
    {
        for (int i = 0; i < currentArea.interactableObjectsInArea.Length; i++)
        {
            string descriptionNotInInventory = interactableItems.GetObjectsNotInInventory(currentArea, i);

            if (descriptionNotInInventory != null)
            {
                areaInteractionDescription.Add(descriptionNotInInventory);
            }

            InteractableObjects interactableInArea = currentArea.interactableObjectsInArea[i];

            for (int j = 0; j < interactableInArea.interactions.Length; j++)
            {
                Interaction interaction = interactableInArea.interactions[j];
                if (interaction.inputAction.keyWord == "examine")
                {
                    interactableItems.examineDictionary.Add(interactableInArea.noun, interaction.textResponse);
                }

                if (interaction.inputAction.keyWord == "take")
                {

                    interactableItems.takeDictionary.Add(interactableInArea.noun, interaction.textResponse);

                }
            }
        }
    }

    public string TestVerbDictionaryWithNoun(Dictionary<string, string> verbDictionary, string verb, string noun)
    {
        if (verbDictionary.ContainsKey(noun))
        {
            return verbDictionary[noun];
        }
        return "You can't " + verb + " " + noun;

    }

    private void ClearCache()
    {

        areaInteractionDescription.Clear();
        areaNavigation.ResetExits();
    }

    //when the player hits enter it will log what they type. declaring a new string varible 
    public void LogWithEnter(string AddString)
    {
        //adding the user input and a space when the player hits enter.
        storyLog.Add(AddString + "\n");

        //Debug.Log(AddString);

    }

	// Update is called once per frame
	void Update () {
		
	}


}
