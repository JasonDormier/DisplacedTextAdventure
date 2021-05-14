using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Player Action/Go")]

public class Go : InputAction {
    //The go action is for when there is another area in the room
    public override void ResponseToPlayer(Controller controller, string[] somethingElse)
    {
        controller.areaNavigation.TryToChangeAreas(somethingElse[1]);
    }

}
