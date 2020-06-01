using Malee.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(ScriptableState))]
public class ScriptableStateEditor : Editor
{
    ReorderableList entryActions;
    ReorderableList stateActions;
    ReorderableList exitActions;
    ReorderableList transitions;

    private void OnEnable()
    {
        entryActions = new ReorderableList(serializedObject.FindProperty("_entryActions"));
        entryActions.elementLabels = false;
        stateActions = new ReorderableList(serializedObject.FindProperty("_stateActions"));
        stateActions.elementLabels = false;
        exitActions = new ReorderableList(serializedObject.FindProperty("_exitActions"));
        exitActions.elementLabels = false;
        transitions = new ReorderableList(serializedObject.FindProperty("_transitions"));
        transitions.elementNameOverride = "Transition";
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        entryActions.DoLayoutList();
        stateActions.DoLayoutList();
        exitActions.DoLayoutList();
        transitions.DoLayoutList();

        serializedObject.ApplyModifiedProperties();
    }
}
