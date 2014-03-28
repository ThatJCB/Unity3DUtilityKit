using UnityEditor;
using UnityEngine;

/// <summary>
/// Creates a slider for floats and ints which only returns whole numbers
/// as the result.
/// </summary>
[CustomPropertyDrawer(typeof(IntRange))]
public class IntRangeDrawer : PropertyDrawer
{

    IntRange source { get { return ((IntRange)attribute); } }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
		if (!ValidateType (position, property, label))
		{
			return;
		}

		// Must reset the tip otherwise all labels get the same tooltip displayed!
		string previousTip = label.tooltip;
		if (!string.IsNullOrEmpty (source.ToolTip))
		{
			label.tooltip = source.ToolTip;
		}

		if (property.propertyType == SerializedPropertyType.Float)
		{
			property.floatValue = Mathf.RoundToInt ( property.floatValue );

			EditorGUI.BeginChangeCheck();

			// Adjusts the max to make sure we can set the maximum value
			EditorGUI.Slider(position, property, (float)source.min, (float)source.max + 0.01f, label);

			if (EditorGUI.EndChangeCheck())
			{
				property.floatValue = Mathf.RoundToInt ( property.floatValue );
			}
		}
		else
		{
			EditorGUI.IntSlider(position, property, source.min, source.max, label);
		}

		// Must reset the tip otherwise all labels get the same tooltip displayed!
		label.tooltip = previousTip;
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
		if (property.propertyType != SerializedPropertyType.Integer &&
		    property.propertyType != SerializedPropertyType.Float)
		{
			// Display the default fields for this property
			EditorGUI.PropertyField (position, property, label, true);
			
			if (!oneTime)
			{
				oneTime = true;
				Debug.LogWarning(this.GetType ().ToString() + " only works with integer and float properties!");
			}
			
			return false;
		}
		
		return true;
	}
	//
	#endregion
	//
	///////////////////////////////////////////////////////////////////////////////////////////////

}
