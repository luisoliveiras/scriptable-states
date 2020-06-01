using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace devludico.ScriptableStates
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/State", fileName = "State")]
    public class ScriptableState : ScriptableObject
    {
        [SerializeField] ScriptableAction[] _entryActions;
        [SerializeField] ScriptableAction[] _exitActions;
        [SerializeField] ScriptableAction[] _physicsActions; //to be run in fixed update
        [SerializeField] ScriptableAction[] _stateActions; //to be run in update
        [SerializeField] StateTransition[] _transitions; //to be run in late update

        /// <summary>
        /// Run in FixedUpdate
        /// </summary>
        public void UpdatePhysics(ScriptableStatesComponent statesComponent)
        {
            foreach (var action in _physicsActions)
            {
                action.Act(statesComponent);
            }
        }

        /// <summary>
        /// Run in Update
        /// </summary>
        public void UpdateState(ScriptableStatesComponent statesComponent)
        {
            foreach (var action in _stateActions)
            {
                action.Act(statesComponent);
            }
        }

        /// <summary>
        /// Run in LateUpdate
        /// </summary>
        public ScriptableState CheckTransitions(ScriptableStatesComponent statesComponent, ScriptableState emptyState)
        {
            Debug.Log("Checking transitions");
            ScriptableState nextState = emptyState;
            for (int i = _transitions.Length - 1; i >= 0; i--)
            {
                ScriptableState candidateState;
                if (_transitions[i].condition.Verify(statesComponent))
                    candidateState = _transitions[i].trueState;
                else
                    candidateState = _transitions[i].falseState;

                if (candidateState != emptyState)
                    nextState = candidateState;
            }
            Debug.Log(nextState.name);
            return nextState;
        }

        public void Begin(ScriptableStatesComponent statesComponent)
        {
            foreach (var action in _entryActions)
            {
                action.Act(statesComponent);
            }
        }

        public void End(ScriptableStatesComponent statesComponent)
        {
            foreach (var action in _exitActions)
            {
                action.Act(statesComponent);
            }
        }
    }
}