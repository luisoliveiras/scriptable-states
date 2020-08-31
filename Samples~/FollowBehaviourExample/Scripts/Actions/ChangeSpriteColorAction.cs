using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using devludico.ScriptableStates;

[CreateAssetMenu(menuName = "Scriptable State Machine/Actions/ChangeSpriteColorAction", fileName = "new ChangeSpriteColorAction")]
public class ChangeSpriteColorAction : ScriptableAction
{
	public Color newColor = Color.white;

	public override void Act(ScriptableStatesComponent statesComponent)
	{
		statesComponent.GetComponent<SpriteRenderer>().color = newColor;
	}
}