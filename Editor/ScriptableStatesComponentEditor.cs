using UnityEditor;
using UnityEngine;

namespace devludico.ScriptableStates
{
    [CustomEditor(typeof(ScriptableStatesComponent))]
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
            EditorGUILayout.ObjectField(serializedObject.FindProperty("_initialState"));
            if (!serializedObject.FindProperty("_initialState").objectReferenceValue)
                EditorGUILayout.HelpBox("Initial state missing, select a state to be your initial state.", MessageType.Warning, true);
            EditorGUILayout.ObjectField(serializedObject.FindProperty("_emptyState"));
            if (!serializedObject.FindProperty("_emptyState").objectReferenceValue)
                EditorGUILayout.HelpBox("Empty state missing, select the _EmptyState asset for this option.", MessageType.Warning, true);

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
            ScriptableStatesComponent component = serializedObject.targetObject as ScriptableStatesComponent;
            if (component.CurrentState)
                return $"<color=green>{component.CurrentState.name}</color>";
            else
                return "<color=red>None</color>";
        }
    }
}

