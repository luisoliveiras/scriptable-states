using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace loophouse.ScriptableStates
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/State Machine", fileName = "State Machine")]
    public class ScriptableStateMachine : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private ScriptableState _initialState;
        [SerializeField] private ScriptableState _emptyState;
        [SerializeField] private List<StateTransition> _transitions;

        private Dictionary<ScriptableState, List<StateTransitionTarget>> _transitionDictionary;

        public ScriptableState InitialState => _initialState; 
        public ScriptableState EmptyState => _emptyState;

        public ScriptableState CheckTransitions(StateComponent stateComponent, ScriptableState currentState)
        {            
            if(_transitionDictionary.TryGetValue(currentState, out var targets))
            {
                foreach (var item in targets)
                {
                    if (item.condition)
                    {
                        if (item.condition.Verify(stateComponent))
                        {
                            if (item.trueState != _emptyState)
                            {
                                if (item.trueState)
                                {
                                    return item.trueState;
                                }
                                else
                                {
                                    Debug.LogError($"[SCRIPTABLE STATE MACHINE] {name}'s Transitions list has an element with a null true state", this);
                                }
                            }
                        }
                        else
                        {
                            if (item.falseState != _emptyState)
                            {
                                if (item.falseState)
                                {
                                    return item.falseState;
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

        public void OnAfterDeserialize()
        {
            _transitionDictionary = new Dictionary<ScriptableState, List<StateTransitionTarget>>();
            foreach (var item in _transitions)
            {
                if (item.originState != null)
                    if (_transitionDictionary.ContainsKey(item.originState))
                    {
                        _transitionDictionary[item.originState].AddRange(item.targets);
                    }
                    else
                    {
                        _transitionDictionary.Add(item.originState, new List<StateTransitionTarget>(item.targets));
                    }
                else
                    Debug.LogError($"[SCRIPTABLE STATE MACHINE] The transition has an element with a null origin state", this);
            }
        }

        public void OnBeforeSerialize()
        {
            
        }
    }
}
