using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace loophouse.ScriptableStates
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/State", fileName = "State")]
    public class ScriptableState : ScriptableObject
    {
        [SerializeField] ScriptableAction[] _entryActions;
        [SerializeField] ScriptableAction[] _exitActions;
        [SerializeField] ScriptableAction[] _physicsActions; //to be run in fixed update
        [SerializeField] ScriptableAction[] _stateActions; //to be run in update
        [SerializeField] StateTransition[] _transitions; //to be run in late update

        public void Begin(ScriptableStatesComponent statesComponent)
        {
            foreach (var action in _entryActions)
            {
                if (action)
                {
                    action.Act(statesComponent);
                }
                else
                {
                    Debug.LogError($"[SCRIPTABLE STATE] {name}'s Entry Actions list has a null element", this);
                }
            }
        }

        public void End(ScriptableStatesComponent statesComponent)
        {
            foreach (var action in _exitActions)
            {
                if (action)
                {
                    action.Act(statesComponent);
                }
                else
                {
                    Debug.LogError($"[SCRIPTABLE STATE] {name}'s Exit Actions list has a null element", this);
                }
            }
        }

        public void UpdatePhysics(ScriptableStatesComponent statesComponent)
        {
            foreach (var action in _physicsActions)
            {
                if (action)
                {
                    action.Act(statesComponent);
                }
                else
                {
                    Debug.LogError($"[SCRIPTABLE STATE] {name}'s Physics Actions list has a null element", this);
                }
            }
        }

        public void UpdateState(ScriptableStatesComponent statesComponent)
        {
            foreach (var action in _stateActions)
            {
                if (action)
                {
                    action.Act(statesComponent);
                }
                else
                {
                    Debug.LogError($"[SCRIPTABLE STATE] {name}'s State Actions list has a null element", this);
                }
            }
        }

        public ScriptableState CheckTransitions(ScriptableStatesComponent statesComponent, ScriptableState emptyState)
        {
            foreach (StateTransition transition in _transitions)
            {
                if (transition.condition)
                {
                    if (transition.condition.Verify(statesComponent))
                    {
                        if (transition.trueState != emptyState)
                        {
                            if (transition.trueState)
                            {
                                return transition.trueState;
                            }
                            else
                            {
                                Debug.LogError($"[SCRIPTABLE STATE] {name}'s Transitions list has an element with a null true state", this);
                            }
                        }
                    }
                    else
                    {
                        if (transition.falseState != emptyState)
                        {
                            if (transition.falseState)
                            {
                                return transition.falseState;
                            }
                            else
                            {
                                Debug.LogError($"[SCRIPTABLE STATE] {name}'s Transitions list has an element with a null false state", this);
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError($"[SCRIPTABLE STATE] {name}'s Transitions list has an element with a null condition", this);
                }
            }
            return emptyState;
        }

    }
}