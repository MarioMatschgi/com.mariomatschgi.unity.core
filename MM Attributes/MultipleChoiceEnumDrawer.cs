#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using MM.Attributes;

[CustomPropertyDrawer(typeof(MultipleChoiceEnumAttribute))]
public class MultipleChoiceEnumAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        _property.intValue = EditorGUI.MaskField(_position, _label, _property.intValue, _property.enumNames);
    }
}

#endif