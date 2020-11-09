using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace loophouse.ScriptableStates
{
    public class ScriptableStatesComponent : MonoBehaviour
    {
        [SerializeField] private ScriptableState _initialState;
        [SerializeField] private ScriptableState _emptyState;
        private ScriptableState _currentState;

        public ScriptableState CurrentState { get => _currentState; }

        private void Start()
        {
            if (!_initialState)
            {
                Debug.LogError($"<b><color=white>{name}</color></b> has no initial state attached to it, the state machine can't be initialized.", this);
                return;
            }

            _currentState = _initialState;
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

        public void CheckTransitions()
        {
            ScriptableState nextState = _currentState.CheckTransitions(this, _emptyState);
            if (nextState != _emptyState)
            {
                _currentState.End(this);
                _currentState = nextState;
                _currentState.Begin(this);
            }
        }

    }
}