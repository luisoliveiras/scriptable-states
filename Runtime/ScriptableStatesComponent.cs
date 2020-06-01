using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableStatesComponent : MonoBehaviour
{
    [SerializeField] ScriptableState _initialState;
    [SerializeField] ScriptableState _emptyState;
    [SerializeField] private ScriptableState _currentState;

    private void Start()
    {
        _currentState = _initialState;
        _currentState.Begin(this);
    }

    private void FixedUpdate()
    {
        _currentState.UpdatePhysics(this);
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    private void LateUpdate()
    {
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
