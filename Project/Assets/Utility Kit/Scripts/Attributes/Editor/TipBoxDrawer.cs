using UnityEditor;
using UnityEngine;
using System;

/// <summary>
/// Display a text box above or below the value.
/// </summary>
[CustomPropertyDrawer(typeof(TipBox))]
public class TipBoxDrawer : PropertyDrawer
{
	private const float spacing = 5f;

    private TipBox source { get { return ((TipBox)attribute); } }

	/// <summary>
	/// Here you must define the height of your property drawer. Called by Unity.
	/// </summary>
	public override float GetPropertyHeight (SerializedProperty prop,
	                                         GUIContent label) 
	{

		float baseSize = ToolTipDrawer.GetOriginalHeight (prop, label);

		Vector2 helpSize = EditorStyles.label.CalcSize (new GUIContent(source.BoxedText));
		return baseSize + helpSize.y + spacing;
	}
	

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
		// Must reset the tip otherwise all labels get the same tooltip displayed!
		string previousTip = label.tooltip;
		if (!string.IsNullOrEmpty (source.TipText))
		{
			label.tooltip = source.TipText;
		}

		Vector2 helpSize = EditorStyles.label.CalcSize (new GUIContent(source.BoxedText));

		// Adjust the size of the box to fit the text and centre.
		Rect boxPosition = position;
		if (boxPosition.width > helpSize.x)
		{
			// Reduce the size of the box
			boxPosition.width = helpSize.x;
			// Centre
			boxPosition.x += ((position.width - boxPosition.width) * 0.5f);
		}

		// Adjust the help box position to appear indented underneath the entry field.
		Rect helpPosition = EditorGUI.IndentedRect (boxPosition);

		helpPosition.height = helpSize.y;

		// Move the position of the value above or below the help message
		Rect textPosition = position;

		float baseHeight = ToolTipDrawer.GetOriginalHeight (property, label);;

		if (source.ShowTipAbove)
		{
			textPosition.y = helpPosition.y + helpPosition.height + spacing;
			helpPosition.y += (spacing * 0.5f);
		}
		else
		{
			helpPosition.y += baseHeight + (spacing * 0.5f);
		}

		textPosition.height = baseHeight;

		// Display the default fields for this property
		EditorGUI.PropertyField (textPosition, property, label, true);

		EditorGUI.HelpBox (helpPosition, source.BoxedText, MessageType.None);

		// Must reset the tip otherwise all labels get the same tooltip displayed!
		label.tooltip = previousTip;
	}


}