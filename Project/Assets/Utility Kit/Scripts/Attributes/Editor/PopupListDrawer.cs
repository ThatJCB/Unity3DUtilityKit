using UnityEditor;
using UnityEngine;
using System;

/// <summary>
/// Creates a popup list with the provided values.
/// 
/// Taken from the example from the following post:
/// 	http://forum.unity3d.com/threads/150337-PropertyDrawers-for-easy-Inspector-customization/page2
/// </summary>
[CustomPropertyDrawer(typeof(PopupList))]
public class PopupListDrawer : PropertyDrawer
{
    PopupList source { get { return ((PopupList)attribute); } }
    int index;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
		if (!ValidateType (position, property, label))
		{
			return;
		}
		
        // Checks to see what is the type of the provided values and acts accordingly.
        if (source.variableType == typeof(int[]))
        {
            EditorGUI.BeginChangeCheck();
            index = EditorGUI.Popup(position, label.text, property.intValue, source.list);
            if (EditorGUI.EndChangeCheck())
            {
                property.intValue = index;
            }
        }
        else if (source.variableType == typeof(float[]))
        {
            EditorGUI.BeginChangeCheck();
            // Checks all items in the provided list, to see if any of them is a match with the property value, if so assigns that value to the index.
            for (int i = 0; i < source.list.Length; i++)
            {
                if (property.floatValue == Convert.ToSingle(source.list[i]))
                {
                    index = i;
                }
            }
            index = EditorGUI.Popup(position, label.text, index, source.list);
            if (EditorGUI.EndChangeCheck())
            {
                property.floatValue = Convert.ToSingle(source.list[index]);
            }
        }
        else if (source.variableType == typeof(string[]))
        {
            EditorGUI.BeginChangeCheck();
            // Checks all items in the provided list, to see if any of them is a match with the property value, if so assigns that value to the index.
            for (int i = 0; i < source.list.Length; i++)
            {
                if (property.stringValue == source.list[i])
                {
                    index = i;
                }
            }
            index = EditorGUI.Popup(position, label.text, index, source.list);
            if (EditorGUI.EndChangeCheck())
            {
                property.stringValue = source.list[index];
            }
        }
        else
        {
            EditorGUI.LabelField(position, "Invalid List Type!");
        }
    }

	///////////////////////////////////////////////////////////////////////////////////////////////
	//
	#region Validation
	//
	private bool oneTime = false;
	/// <summary>
	/// Validates the type that the drawer is applied to.
	/// If not valid it will draw the default field for this type
	/// and log an error.
	/// 
	/// Returns false if the type is not valid for this class.
	/// Use that to stop the rest of the GUI drawing.
	/// 
	/// Usage:
	/// 
	/// void OnGUI(...)
	/// }
	/// 	if (!ValidateType (position, property, label))
	/// 	{
	/// 		return;
	/// 	}
	/// 
	/// 	// Draw stuff here ...
	/// }
	///
	/// </summary>
	private bool ValidateType(Rect position, SerializedProperty property, GUIContent label)
	{
		if (property.propertyType == SerializedPropertyType.Integer ||
		    property.propertyType == SerializedPropertyType.Float ||
		    property.propertyType == SerializedPropertyType.String)
		{
			return true;
		}

		// Display the default fields for this property
		EditorGUI.PropertyField (position, property, label, true);
		
		if (!oneTime)
		{
			oneTime = true;
			Debug.LogWarning(this.GetType ().ToString() + " only works with integer, float and string properties!");
		}
		
		return false;
	}
	//
	#endregion
	//
	///////////////////////////////////////////////////////////////////////////////////////////////

}