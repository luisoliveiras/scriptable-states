using UnityEngine;
using devludico.ScriptableStates;

[CreateAssetMenu(menuName = "Scriptable State Machine/Conditions/RadialTargetDetectionCondition", fileName = "new RadialTargetDetectionCondition")]
public class RadialTargetDetectionCondition : ScriptableCondition
{
	public float detectionRadius;
	public LayerMask detectionLayer;

	public override bool Verify(ScriptableStatesComponent smComponent)
	{
		Vector2 position = smComponent.transform.position;
		Transform target = Physics2D.OverlapCircle(position, detectionRadius, detectionLayer)?.transform;

		EnemyComponent component = smComponent.GetComponent<EnemyComponent>();
		if (component)
		{
			component.SetTarget(target);
		}

		return target != null;
	}
}