using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour {

    public List<InteractableObjects> usableItemList;
    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();

    [HideInInspector] public List<string> nounsInArea = new List<string>();

    private Dictionary<string, Actions> useDictionary = new Dictionary<string, Actions>();
    //create something like  above line for an ask dictionary.

    private List<string> nounsInInventory = new List<string>();

    private Controller controller;

    public void Awake()
    {

        controller = GetComponent<Controller>();
    }

    public string GetObjectsNotInInventory(GameArea currentArea, int i)
    {

        InteractableObjects interactableInArea = currentArea.interactableObjectsInArea[i];

        if (!nounsInInventory.Contains(interactableInArea.noun))
        {

            nounsInArea.Add(interactableInArea.noun);
            return interactableInArea.description;

        }

        return null;
    }

    public void AddActionResponsesToUseDictionary()
    {

        for (int i = 0; i < nounsInInventory.Count; i++)
        {

            string noun = nounsInInventory[i];

            InteractableObjects interactableObjectInInventory = GetInteractableObjectFromUsableList(noun);
            if (interactableObjectInInventory == null)

                continue;

            for (int j = 0; j < interactableObjectInInventory.interactions.Length; j++)
            {
                Interaction interaction = interactableObjectInInventory.interactions[j];

                if (interaction.action == null)
                    continue;
                if (!useDictionary.ContainsKey(noun))
                {
                    useDictionary.Add(noun, interaction.action);
                }
            }
        }
    }

    InteractableObjects GetInteractableObjectFromUsableList(string noun)
    {
        for (int i = 0; i < usableItemList.Count; i++)
        {
            if (usableItemList[i].noun == noun)
            {
                return usableItemList[i];
            }
        }

        return null;
    }

    public void DisplayInventory()
    {
        controller.LogWithEnter("You look in your backpack, inside you have: ");
        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            controller.LogWithEnter(nounsInInventory[i]);

        }
    }

    public void ClearCollections()
    {

        examineDictionary.Clear();
        takeDictionary.Clear();
        nounsInArea.Clear();

    }

    public Dictionary<string, string> Take(string[] seperatedInputWords)
    {

        string noun = seperatedInputWords[1];

        if (nounsInArea.Contains(noun))
        {
            nounsInInventory.Add(noun);
            AddActionResponsesToUseDictionary();
            nounsInArea.Remove(noun);

            return takeDictionary;

        }
        else
        {

            controller.LogWithEnter("There is no " + noun + " here to take.");
            return null;
        }
    }

    public void UseItem(string[] seperatedInputWords)
    {
        string nounToUse = seperatedInputWords[1];

        if (nounsInInventory.Contains(nounToUse))
        {
            if (useDictionary.ContainsKey(nounToUse))
            {
                bool actionResult = useDictionary[nounToUse].DoActionResponse(controller);
                if (!actionResult)
                {
                    controller.LogWithEnter("Hmmm, Nothing happens.");
                }
            }
            else
            {
                controller.LogWithEnter("You can't use the " + nounToUse);
            }
        }
        else
        {
            controller.LogWithEnter("There is no " + nounToUse + "in your inventory.");

        }
    }

}
