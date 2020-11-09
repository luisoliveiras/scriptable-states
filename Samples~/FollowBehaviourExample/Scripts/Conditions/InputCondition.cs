using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using loophouse.ScriptableStates;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[CreateAssetMenu(menuName = "Scriptable State Machine/Conditions/InputCondition", fileName = "new InputCondition")]
public class InputCondition : ScriptableCondition
{
	public InputActionAsset inputActionAsset;
	public string actionName;
	private InputAction _inputAction;
	ButtonControl _button;

	private void OnEnable()
	{
		_inputAction = inputActionAsset.FindAction(actionName);
	}

	public override bool Verify(ScriptableStatesComponent statesComponent)
	{
		_button = _inputAction.activeControl as ButtonControl;
		if (_button != null)
		{
			return _button.isPressed;
		}

		return false;
	}


}
