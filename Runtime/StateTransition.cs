
using System.Collections.Generic;

namespace loophouse.ScriptableStates
{
    [System.Serializable]
    public struct StateTransition
    {
        public List<ScriptableState> originStates;
        //public ScriptableState originState;
        public ScriptableCondition condition;
        public ScriptableState trueState;
        public ScriptableState falseState;
    }
}