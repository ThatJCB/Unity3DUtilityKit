using UnityEditor;
using UnityEngine;
using System;

/// <summary>
/// Draw a line spacer above or below the property and optionally
/// display text when the mouse is over the label.
/// </summary>
[CustomPropertyDrawer(typeof(Divider))]
public class DividerDrawer : PropertyDrawer
{
	private const float thickness = 2f;
	private const float space = 7f;
	private static Color colour = Color.grey;

    private Divider source { get { return ((Divider)attribute); } }

	/// <summary>
	/// The height returned here must be appropriate for the property
	/// being dawn.
	/// </summary>
	public override float GetPropertyHeight (SerializedProperty property,
	                                         GUIContent label) 
	{
		return ToolTipDrawer.GetOriginalHeight (property, label) + thickness + (2f * space);
	}

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
		// Must reset the tip otherwise all labels get the same tooltip displayed!
		string previousTip = label.tooltip;
		if (!string.IsNullOrEmpty (source.TipText))
		{
			label.tooltip = source.TipText;
		}

		float gap = thickness + (2f * space);
		float original = ToolTipDrawer.GetOriginalHeight (property, label);

		Rect textPosition = position;
		Rect linePosition = position;
		linePosition.height = thickness;

		if (source.SpaceAbove)
		{
			textPosition.y += gap;
			linePosition.y += space;
		}
		else
		{
			linePosition.y += original + space;
		}

		// Display the default fields for this property
		EditorGUI.PropertyField (textPosition, property, label, true);

		// Must reset the tip otherwise all labels get the same tooltip displayed!
		label.tooltip = previousTip;

		// Divider
		EditorGUI.DrawRect(linePosition, colour);
		
		

	}

}