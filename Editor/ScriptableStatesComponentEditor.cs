using UnityEditor;
using UnityEngine;

namespace loophouse.ScriptableStates
{
    [CustomEditor(typeof(StateComponent))]
    public class ScriptableStatesComponentEditor : Editor
    {
        Color _rectColor;
        GUIStyle _richTextStyle;
        private void OnEnable()
        {
            _rectColor = new Color(0, 0, 0, 0.2f);
            _richTextStyle = new GUIStyle() { richText = true };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.Space();
            EditorGUILayout.ObjectField(serializedObject.FindProperty("_stateMachine"));
            if (!serializedObject.FindProperty("_stateMachine").objectReferenceValue)
                EditorGUILayout.HelpBox("State Machine missing, select a state machine to run.", MessageType.Warning, true);

            EditorGUILayout.Space();
            Rect horizontalGroup = EditorGUILayout.BeginHorizontal();
            EditorGUI.DrawRect(horizontalGroup, _rectColor);
            EditorGUILayout.LabelField("<color=white><b> Current State:</b></color>", _richTextStyle);
            GUILayout.Box(GetCurrentStateName(), _richTextStyle);
            EditorGUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();
        }

        private string GetCurrentStateName()
        {
            StateComponent component = serializedObject.targetObject as StateComponent;
            if (component.CurrentState)
                return $"<color=green>{component.CurrentState.name}</color>";
            else
                return "<color=red>None</color>";
        }
    }
}

