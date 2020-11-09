using Malee.List;
using UnityEditor;


namespace loophouse.ScriptableStates
{
    [CustomEditor(typeof(ScriptableState))]
    public class ScriptableStateEditor : Editor
    {
        ReorderableList entryActions;
        ReorderableList exitActions;
        ReorderableList stateActions;
        ReorderableList physicsActions;
        ReorderableList transitions;

        private void OnEnable()
        {
            entryActions = new ReorderableList(serializedObject.FindProperty("_entryActions"));
            entryActions.elementLabels = false;
            exitActions = new ReorderableList(serializedObject.FindProperty("_exitActions"));
            exitActions.elementLabels = false;
            physicsActions = new ReorderableList(serializedObject.FindProperty("_physicsActions"));
            physicsActions.elementLabels = false;
            stateActions = new ReorderableList(serializedObject.FindProperty("_stateActions"));
            stateActions.elementLabels = false;
            transitions = new ReorderableList(serializedObject.FindProperty("_transitions"));
            transitions.elementNameOverride = "Transition";
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            entryActions.DoLayoutList();
            exitActions.DoLayoutList();
            physicsActions.DoLayoutList();
            stateActions.DoLayoutList();
            transitions.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }
    }
}