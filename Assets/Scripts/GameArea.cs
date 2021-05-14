using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/GameArea")]

public class GameArea : ScriptableObject {

    [TextArea(10, 14)] public string description;
    public string areaName;

    //creating an empty array that will be filled with the unity interface.
    public Exits[] exits;
    public InteractableObjects[] interactableObjectsInArea;

}
