using UnityEditor;
using UnityEngine;
using System;

/// <summary>
/// Creates a popup list with the provided values.
/// 
/// With ideas from the following posts:
/// 	http://forum.unity3d.com/threads/150337-PropertyDrawers-for-easy-Inspector-customization/page2
/// 	http://answers.unity3d.com/questions/33263/how-to-get-names-of-all-available-levels.html?sort=oldest
/// </summary>
[CustomPropertyDrawer(typeof(SceneNameList))]
public class SceneNameListDrawer : PropertyDrawer
{
	private const float spacer = 2f;
	private const float toggleWidth = 14f;
	private const int invalidIndex = -1;
	private const string invalidPrefix = "*NOT VALID*[";
	private const string invalidSuffix = "]";
	/// <summary>
	/// Populated only if the original value does not match anything from the list.
	/// This is so that the original value can be retained if required.
	/// </summary>
	private string invalidValue = "";

    private SceneNameList source { get { return ((SceneNameList)attribute); } }
    private int index;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
		if (!ValidateType (position, property, label))
		{
			return;
		}

		// Must reset the tip otherwise all labels get the same tooltip displayed!
		string previousTip = label.tooltip;
		label.tooltip = SceneNameList.ToolTip;

	    EditorGUI.BeginChangeCheck();

		if (string.IsNullOrEmpty (property.stringValue))
		{
			// Blank
			index = 0;
		}
		else
		{
			index = MatchValid (property);
			if (index == invalidIndex)
			{
				// The scene is not in the build list!
				string tempText = invalidPrefix + property.stringValue + invalidSuffix;
				if (string.IsNullOrEmpty (source.DisplayList[source.DisplayList.Length - 1].text))
				{
					// Add as the last entry
					source.DisplayList[source.DisplayList.Length - 1].text = tempText;
					invalidValue = property.stringValue;
				}
				// Check if the invalid scene is in the display list
				index = MatchDisplay (tempText);
				if (index == invalidIndex)
				{
					index = 0;
					Debug.LogWarning ("This should never happen!\n" +
					                  "The scene name does not even match the initial invalid value!");
				}
			}
		}

		Rect popupPosition = position;

		Rect togglePosition = position;
		togglePosition.width = toggleWidth;

		popupPosition.width -= (togglePosition.width + spacer);
		togglePosition.x = popupPosition.x + popupPosition.width + spacer;

		// Use to refresh the list of scene names
		bool refresh = EditorGUI.Toggle (togglePosition, false);

	    index = EditorGUI.Popup(popupPosition, label, index, source.DisplayList);

	    if (EditorGUI.EndChangeCheck())
	    {
			if (index > 0 && index < source.ValidList.Length)
			{
				// Valid item
				property.stringValue = source.ValidList[index];
			}
			else if (index == 0)
			{
				// Blank item
				property.stringValue = "";
			}
			else if (index == source.DisplayList.Length - 1 &&
			         !string.IsNullOrEmpty (invalidValue))
			{
				// Invalid item
				property.stringValue = invalidValue;
			}

			if (refresh)
			{
				source.RefreshLists ();
			}
	    }

		// Must reset the tip otherwise all labels get the same tooltip displayed!
		label.tooltip = previousTip;
    }

	/// <summary>
	/// Matches the existing value and returns the index
	/// Returns -1 if there is no match.
	/// </summary>
	private int MatchValid(SerializedProperty property)
	{
		int result = invalidIndex;
		// Checks all items in the provided list, to see if any of them is a match with the property value, 
		// if so assigns that value to the index.
		for (int i = 1; i < source.ValidList.Length; i++)
		{
			if (property.stringValue == source.ValidList[i])
			{
				return i;
			}
		}
		return result;
	}

	/// <summary>
	/// Matches the existing value and returns the index.
	/// Returns -1 if there is no match.
	/// </summary>
	private int MatchDisplay(string itemText)
	{
		int result = invalidIndex;
		// Checks all items in the provided list, to see if any of them is a match with the value, 
		// if so assigns that value to the index.
		for (int i = 1; i < source.DisplayList.Length; i++)
		{
			if (itemText == source.DisplayList[i].text)
			{
				return i;
			}
		}
		return result;
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
		if (property.propertyType != SerializedPropertyType.String)
		{
			// Display the default fields for this property
			EditorGUI.PropertyField (position, property, label, true);
			
			if (!oneTime)
			{
				oneTime = true;
				Debug.LogWarning(this.GetType ().ToString() + " only works with string properties!");
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