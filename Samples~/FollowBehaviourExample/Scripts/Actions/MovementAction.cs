using UnityEngine;
using loophouse.ScriptableStates;

[CreateAssetMenu(menuName = "Scriptable State Machine/Actions/MovementAction", fileName = "new MovementAction")]
public class MovementAction : ScriptableAction
{
	public float speed;
	public override void Act(StateComponent statesComponent)
	{
		statesComponent.GetComponent<IMovable>().Move(speed);
	}
}