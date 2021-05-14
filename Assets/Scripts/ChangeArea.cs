using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/ActionResponse/ChangeArea")]

public class ChangeArea : Actions {

    public GameArea changeThisArea;

    public override bool DoActionResponse(Controller controller)
    {
        if(controller.areaNavigation.currentArea.areaName == requiredInput)
        {

            controller.areaNavigation.currentArea = changeThisArea;
            controller.DisplayStoryAreaText();
            return true;
        }

        return false;
    }

}
