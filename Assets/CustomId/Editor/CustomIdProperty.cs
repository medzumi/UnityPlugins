using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(CustomId))]
public class CustomIdProperty : PropertyDrawer
{
    private string currentId;
    private CustomIdArray array;

    private int index;

    private SerializedProperty idProperty;
    private SerializedProperty arrayProperty;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 75;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();
        EditorGUI.DrawRect(position, Color.black);
        EditorGUI.PrefixLabel(new Rect(position.x, position.y, position.width, 20), label);
        EditorGUI.indentLevel +=1;
        if(idProperty ==null || arrayProperty==null)
        {
            idProperty = property.FindPropertyRelative("currentId");
            arrayProperty = property.FindPropertyRelative("array");
        }
        currentId = idProperty.stringValue;
        array = arrayProperty.objectReferenceValue as CustomIdArray;
        if (array)
        {
            DrawWithArray(position);
        }
        else
        {
            DrawWithoutArray(position);
        }
        EditorGUI.indentLevel -= 1;
        EditorGUI.EndChangeCheck();
    }

    private void DrawWithoutArray(Rect position)
    {
        EditorGUI.PropertyField(new Rect(position.x, position.y + (position.height - 35) / 2 + 30, position.width - 5, (position.height-35) / 2), arrayProperty);
        EditorGUI.PropertyField(new Rect(position.x, position.y + 25, position.width - 5, (position.height - 35) / 2), idProperty);
    }

    private void DrawWithArray(Rect position)
    {
        EditorGUI.PropertyField(new Rect(position.x, position.y + (position.height - 35) / 2 + 30, position.width - 5, (position.height - 35) / 2), arrayProperty);
        index = -1;
        for (int i = 0; i < array.AvailableIds.Length; i++)
        {
            if(array.AvailableIds[i] == currentId)
            {
                index = i;
            }
        }
        if(index >= 0)
        {
            
        }
        else
        {
        }

        var newInd = EditorGUI.Popup(new Rect(position.x, position.y + 25, position.width - 5, (position.height - 35) / 2), idProperty.name, index, array.AvailableIds);
        if (index != newInd)
        {
            index = newInd;
            idProperty.stringValue = array.AvailableIds[index];
        }
    }
}
