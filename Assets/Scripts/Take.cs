using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Player Action/Take")]

public class Take : InputAction {

    public override void ResponseToPlayer(Controller controller, string[] seperatedInputWords)
    {
        Dictionary<string, string> takeDictionary = controller.interactableItems.Take(seperatedInputWords);

        if(takeDictionary != null)
        {
            controller.LogWithEnter(controller.TestVerbDictionaryWithNoun(takeDictionary, seperatedInputWords[0], seperatedInputWords[1]));
        }
    }
}
