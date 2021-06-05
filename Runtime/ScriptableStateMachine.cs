using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace loophouse.ScriptableStates
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/State Machine", fileName = "State Machine")]
    public class ScriptableStateMachine : ScriptableObject
    {
        [SerializeField] private ScriptableState _initialState;
        [SerializeField] private ScriptableState _emptyState;
        [SerializeField] private List<StateTransition> _transitions;

        public ScriptableState InitialState { get => _initialState; }
        public ScriptableState EmptyState { get => _emptyState; }

        public ScriptableState CheckTransitions(StateComponent stateComponent, ScriptableState currentState)
        {
            foreach (StateTransition transition in _transitions)
            {
                if (transition.originState == currentState)
                {
                    if (transition.condition)
                    {
                        if (transition.condition.Verify(stateComponent))
                        {
                            if (transition.trueState != _emptyState)
                            {
                                if (transition.trueState)
                                {
                                    return transition.trueState;
                                }
                                else
                                {
                                    Debug.LogError($"[SCRIPTABLE STATE MACHINE] {name}'s Transitions list has an element with a null true state", this);
                                }
                            }
                        }
                        else
                        {
                            if (transition.falseState != _emptyState)
                            {
                                if (transition.falseState)
                                {
                                    return transition.falseState;
                                }
                                else
                                {
                                    Debug.LogError($"[SCRIPTABLE STATE MACHINE] {name}'s Transitions list has an element with a null false state", this);
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError($"[SCRIPTABLE STATE MACHINE] {name}'s Transitions list has an element with a null condition", this);
                    }
                }
            }
            return _emptyState;
        }
    }
}
