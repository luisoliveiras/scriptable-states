using System;
using UnityEngine;

namespace loophouse.ScriptableStates
{
    public class StateComponent : MonoBehaviour
    {
        [SerializeField] private ScriptableStateMachine _stateMachine;
        private ScriptableState _currentState;

        public ScriptableState CurrentState { get => _currentState; }
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
                MakeTransition(nextState);
            }
        }

        public void MakeTransition(ScriptableState nextState)
        {
            _currentState.End(this);
            var previousState = CurrentState;
            _currentState = nextState;
            _currentState.Begin(this);

            OnStateChanged?.Invoke(previousState, nextState);
        }

    }
}