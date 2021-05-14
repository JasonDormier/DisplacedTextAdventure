using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actions : ScriptableObject{

    public string requiredInput;

    public abstract bool DoActionResponse(Controller controller);
}
