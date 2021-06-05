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

        public void Begin(StateComponent stateComponent)
        {
            foreach (var action in _entryActions)
            {
                if (action)
                {
                    action.Act(stateComponent);
                }
                else
                {
                    Debug.LogError($"[SCRIPTABLE STATE] {name}'s Entry Actions list has a null element", this);
                }
            }
        }

        public void End(StateComponent stateComponent)
        {
            foreach (var action in _exitActions)
            {
                if (action)
                {
                    action.Act(stateComponent);
                }
                else
                {
                    Debug.LogError($"[SCRIPTABLE STATE] {name}'s Exit Actions list has a null element", this);
                }
            }
        }

        public void UpdatePhysics(StateComponent stateComponent)
        {
            foreach (var action in _physicsActions)
            {
                if (action)
                {
                    action.Act(stateComponent);
                }
                else
                {
                    Debug.LogError($"[SCRIPTABLE STATE] {name}'s Physics Actions list has a null element", this);
                }
            }
        }

        public void UpdateState(StateComponent stateComponent)
        {
            foreach (var action in _stateActions)
            {
                if (action)
                {
                    action.Act(stateComponent);
                }
                else
                {
                    Debug.LogError($"[SCRIPTABLE STATE] {name}'s State Actions list has a null element", this);
                }
            }
        }
    }
}