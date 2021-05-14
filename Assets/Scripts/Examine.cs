using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Player Action/Examine")]

public class Examine : InputAction {

    public override void ResponseToPlayer(Controller controller, string[] seperatedInputWords)
    {
        controller.LogWithEnter(controller.TestVerbDictionaryWithNoun(controller.interactableItems.examineDictionary, seperatedInputWords[0], seperatedInputWords[1]));
    }
}
