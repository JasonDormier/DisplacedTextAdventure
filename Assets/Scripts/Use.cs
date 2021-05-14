using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Player Action/Use")]

public class Use : InputAction {

    public override void ResponseToPlayer(Controller controller, string[] seperatedInputWords)
    {
        controller.interactableItems.UseItem(seperatedInputWords);
    }
}
