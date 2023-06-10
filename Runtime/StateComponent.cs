using System;
using UnityEngine;

namespace loophouse.ScriptableStates
{
    public class StateComponent : MonoBehaviour
    {
        [SerializeField] private ScriptableStateMachine _stateMachine;
        private ScriptableState _currentState;

        public ScriptableState CurrentState => _currentState;
        /// <summary>
        /// T1: Previous State, T2: Current State
        /// </summary>
        public Action<ScriptableState, ScriptableState> OnStateChanged;

        private void Start()
        {
            if (!_stateMachine.InitialState)
            {
                Debug.LogError($"<b><color=white>{_stateMachine.name}</color></b> has no initial state attached to it, the state machine can't be initialized.", this);
                return;
            }

            _currentState = _stateMachine.InitialState;
            _currentState.Begin(this);
        }

        private void FixedUpdate()
        {
            if (!_currentState)
                return;

            _currentState.UpdatePhysics(this);
        }

        private void Update()
        {
            if (!_currentState)
                return;

            _currentState.UpdateState(this);
        }

        private void LateUpdate()
        {
            if (!_currentState)
                return;

            CheckTransitions();
        }

        private void CheckTransitions()
        {
            ScriptableState nextState = _stateMachine.CheckTransitions(this, _currentState);
            if (nextState != _stateMachine.EmptyState)
            {
                _currentState.End(this);
                var previousState = CurrentState;
                _currentState = nextState;
                _currentState.Begin(this);

                OnStateChanged?.Invoke(previousState,nextState);
            }
        }

        public void MoveToState(ScriptableState targetState)
        {
            _currentState.End(this);
            var previousState = CurrentState;
            _currentState = targetState;
            _currentState.Begin(this);

            OnStateChanged?.Invoke(previousState, targetState);
        }

        // Create a Method to get a registered component in this state component.
        // There should be a dictionary of components, so there is direct access to them.
        // There could be a interface for this components, with a common property being something like a tag that could be used as dictionary key.


    }
}