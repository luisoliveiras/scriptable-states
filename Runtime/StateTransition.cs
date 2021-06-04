
namespace loophouse.ScriptableStates
{
    [System.Serializable]
    public struct StateTransition
    {
        public ScriptableCondition condition;
        public ScriptableState trueState;
        public ScriptableState falseState;
    }
}