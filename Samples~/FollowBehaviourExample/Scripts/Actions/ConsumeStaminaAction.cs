using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using devludico.ScriptableStates;

[CreateAssetMenu(menuName = "Scriptable State Machine/Actions/ConsumeStaminaAction", fileName = "new ConsumeStaminaAction")]
public class ConsumeStaminaAction : ScriptableAction
{
	public override void Act(ScriptableStatesComponent statesComponent)
	{
		statesComponent.GetComponent<StaminaComponent>().ConsumeStamina();
	}
}