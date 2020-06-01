using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StateTransition
{
    public ScriptableCondition condition;
    public ScriptableState trueState;
    public ScriptableState falseState;
}
