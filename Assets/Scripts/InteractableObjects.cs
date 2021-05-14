using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Interactable Object")]

public class InteractableObjects : ScriptableObject {

    public string noun = "name";
    [TextArea (10,14)] public string description = "Description of Object";
    public Interaction[] interactions;
}
