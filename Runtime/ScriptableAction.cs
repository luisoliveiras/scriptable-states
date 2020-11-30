using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace loophouse.ScriptableStates
{
    public abstract class ScriptableAction : ScriptableObject
    {
        public abstract void Act(ScriptableStatesComponent statesComponent);
    }
}