using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Player Action/Inventory")]

public class Inventory : InputAction {

    public override void ResponseToPlayer(Controller controller, string[] seperatedInputWords)
    {
        controller.interactableItems.DisplayInventory();
    }
}
