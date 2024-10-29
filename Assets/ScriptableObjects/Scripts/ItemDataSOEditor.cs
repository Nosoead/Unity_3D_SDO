using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemDataSO))]
public class ItemDataSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ItemDataSO itemDataSO = (ItemDataSO)target;

        GUILayout.Label("Info", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("displayName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("description"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("itemType"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("icon"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("dropPrefab"));

        GUILayout.Label("Stacking", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("canStack"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("maxStackAmount"));

        switch (itemDataSO.itemType)
        {
            case ItemType.Equipable:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("equipmentSlotType"), new GUIContent("equipment Slot Type"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("equipPrefab"), new GUIContent("Equip Prefab"));
                break;
            case ItemType.Consumable:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("consumables"), new GUIContent("consumables"));
                break;
            case ItemType.Quest:
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
