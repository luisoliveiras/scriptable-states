using System;

namespace loophouse.ScriptableStates
{
    [Serializable]
    public class StateTransition
    {
        public ScriptableState originState;
        public StateTransitionTarget[] targets;
    }

    [Serializable]
    public class StateTransitionTarget
    {
        public ScriptableCondition condition;
        public ScriptableState trueState;
        public ScriptableState falseState;
    }
}