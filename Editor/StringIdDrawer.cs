using UnityEditor;
using UnityEngine;

namespace StringIdDrawer.Editor
{
    public abstract class StringIdDrawer : IdDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            if (DrawField)
            {
                height *= 2;
            }

            return height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.LabelField(position, property.displayName, "ERROR: May only apply to type string");
                return;
            }

            base.OnGUI(position, property, label);
        }

        protected override void OnCallback(SerializedProperty property, string value)
        {
            property.stringValue = value;
            property.serializedObject.ApplyModifiedProperties();
        }

        protected override Object GetObject(SerializedProperty property) => GetObject(property.stringValue);

        protected virtual Object GetObject(string value) => null;
    }
}