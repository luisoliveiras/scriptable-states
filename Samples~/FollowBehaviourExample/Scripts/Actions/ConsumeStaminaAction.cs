using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using loophouse.ScriptableStates;

[CreateAssetMenu(menuName = "Scriptable State Machine/Actions/ConsumeStaminaAction", fileName = "new ConsumeStaminaAction")]
public class ConsumeStaminaAction : ScriptableAction
{
	public override void Act(StateComponent statesComponent)
	{
		statesComponent.GetComponent<StaminaComponent>().ConsumeStamina();
	}
}