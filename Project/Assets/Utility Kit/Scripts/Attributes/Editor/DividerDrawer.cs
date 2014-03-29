using UnityEditor;
using UnityEngine;
using System;

/// <summary>
/// Draw a spacer above or below the property and optionally
/// displays a heading under the line and tool tip
/// text when the mouse is over the label.
/// </summary>
[CustomPropertyDrawer(typeof(Divider))]
public class DividerDrawer : PropertyDrawer
{
	private const float thickness = 5f;
	private const float space = 6f;

	private const float lineMultiplier = 1.5f;

    private Divider source { get { return ((Divider)attribute); } }

	/// <summary>
	/// The height returned here must be appropriate for the property
	/// being dawn.
	/// </summary>
	public override float GetPropertyHeight (SerializedProperty property,
	                                         GUIContent label) 
	{
		float lineHeight = 0;
		if (!string.IsNullOrEmpty(source.Heading))
		{
			lineHeight = (EditorStyles.label.lineHeight * lineMultiplier);
		}

		return ToolTipDrawer.GetOriginalHeight (property, label) + thickness + (2f * space) + lineHeight;
	}

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
		// Must reset the tip otherwise all labels get the same tooltip displayed!
		string previousTip = label.tooltip;
		if (!string.IsNullOrEmpty (source.TipText))
		{
			label.tooltip = source.TipText;
		}

		bool hasHead = false;
		float head = 0;
		float gap = thickness + (2f * space);
		float original = ToolTipDrawer.GetOriginalHeight (property, label);

		Rect headPosition = position;
		Rect textPosition = position;
		Rect linePosition = position;
		linePosition.height = thickness;

		if (!string.IsNullOrEmpty (source.Heading))
		{
			hasHead = true;
			head = (EditorStyles.label.lineHeight * lineMultiplier);
			headPosition.height = head;
		}

		if (source.SpaceAbove)
		{
			textPosition.y += gap + head;
			linePosition.y += space;
		}
		else
		{
			linePosition.y += original + space;
		}

		headPosition.y = linePosition.y + space + thickness;

		// Display the default fields for this property
		EditorGUI.PropertyField (textPosition, property, label, true);

		// Must reset the tip otherwise all labels get the same tooltip displayed!
		label.tooltip = previousTip;

		// Divider
		// I tried to use a rectangle but it did not draw reliably but the
		// empty help box does.
		EditorGUI.HelpBox (linePosition, "", MessageType.None);

		if (hasHead)
		{
			EditorGUI.LabelField(headPosition, source.Heading);
		}
	}

}