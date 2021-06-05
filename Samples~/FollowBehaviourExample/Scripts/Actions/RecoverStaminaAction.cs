using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using loophouse.ScriptableStates;

[CreateAssetMenu(menuName = "Scriptable State Machine/Actions/RecoverStaminaAction", fileName = "new RecoverStaminaAction")]
public class RecoverStaminaAction : ScriptableAction
{
	public override void Act(StateComponent statesComponent)
	{
		statesComponent.GetComponent<StaminaComponent>().RecoverStamina();
	}
}