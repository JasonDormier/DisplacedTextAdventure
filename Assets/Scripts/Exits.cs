using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   

public class Exits  {

    //The key that will be used to unlock the next area.
    public string keyString;

    //adding the desctiption area in the UI
    [TextArea(10, 14)] public string exitDescription;
    
    //adding the slot in the UI for the next area
    public GameArea nextArea;

}
