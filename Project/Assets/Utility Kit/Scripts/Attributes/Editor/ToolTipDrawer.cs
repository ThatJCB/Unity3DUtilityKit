using UnityEditor;
using UnityEngine;
using System;

/// <summary>
/// Display a text box under the value.
/// </summary>
[CustomPropertyDrawer(typeof(ToolTip))]
public class ToolTipDrawer : PropertyDrawer
{
    private ToolTip source { get { return ((ToolTip)attribute); } }

	/// <summary>
	/// The height returned here must be appropriate for the property
	/// being dawn.
	/// </summary>
	public override float GetPropertyHeight (SerializedProperty property,
	                                         GUIContent label) 
	{
		return GetOriginalHeight (property, label);
	}

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
		// Must reset the tip otherwise all labels get the same tooltip displayed!
		string previousTip = label.tooltip;
		if (!string.IsNullOrEmpty (source.TipText))
		{
			label.tooltip = source.TipText;
		}

		// Display the default fields for this property
		EditorGUI.PropertyField (position, property, label, true);

		// Must reset the tip otherwise all labels get the same tooltip displayed!
		label.tooltip = previousTip;
	}

	/// <summary>
	/// Returns the height of the default control.
	/// 
	/// This can be reused by other property drawers.
	/// </summary>
	public static float GetOriginalHeight (SerializedProperty prop,
	                                       GUIContent label) 
	{
		const float spacing = 3f;
		
		float baseSize = EditorStyles.label.lineHeight;
		
		// Most types only use one line so they work with the base but a few are 
		// multiline and need more work.
		float extraLines = 0f;
		if (prop.propertyType == SerializedPropertyType.Bounds)
		{
			extraLines = EditorStyles.label.lineHeight * 2.2f;
			baseSize = baseSize + extraLines + spacing;
		}
		else if (prop.propertyType == SerializedPropertyType.Rect)
		{
			extraLines = EditorStyles.label.lineHeight * 1f;
			baseSize = baseSize + extraLines + spacing;
		}
		
		return baseSize + spacing;
	}
}