using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Shows a list of scene names that are in the build settings.
/// 
/// =====================================================================================
/// Usage examples:
/// 
/// [SceneName()]
/// public string LaunchScene;
/// 
/// [SceneName(true)]	// To make the entry display a required message
/// public string LaunchScene;
/// 
/// =====================================================================================
/// 
/// With ideas from the following posts:
/// 	http://forum.unity3d.com/threads/150337-PropertyDrawers-for-easy-Inspector-customization/page2
/// 	http://answers.unity3d.com/questions/33263/how-to-get-names-of-all-available-levels.html?sort=oldest
/// </summary>
public class SceneNameList : PropertyAttribute
{
	public const string ToolTip = "Press the small button to refresh the scene list";

    public string[] ValidList;
	// Using GUIContent so we can add tool tips
	public GUIContent[] DisplayList;

	public bool Required = false;

    /// <summary>
	/// Shows a list of scene names that are in the build settings.
	/// </summary>
    public SceneNameList()
    {
		Required = false;
		RefreshLists ();
	}

	/// <summary>
	/// Shows a list of scene names that are in the build settings.
	/// </summary>
	public SceneNameList(bool requiresAnEntry)
	{
		Required = requiresAnEntry;
		RefreshLists ();
	}

	public void RefreshLists()
	{
		ValidList = ReadSceneList (Required);
		UpdateDisplayList ();
	}
	
	private void UpdateDisplayList()
	{
		List<string> temp = new List<string>();
		if (Required)
		{
			temp.Add ("-Required-");
		}
		else
		{
			temp.Add ("-Optional-");
		}
		// Ignores the first line which has been replaced above
		for (int i = 1; i < ValidList.Length; i++)
		{
			temp.Add (ValidList[i]);
		}

		// Placeholder to save having to enlarge the array for invalid items
		temp.Add("");

		DisplayList = new GUIContent[temp.Count];

		for (int i = 0; i < temp.Count; i++)
		{
			DisplayList[i] = new GUIContent(temp[i], ToolTip);
		}
	}

	private static string[] ReadSceneList(bool requiresAnEntry)
	{
		List<string> temp = new List<string>();
		// Add a blank item so the indices of the display and valid lists are the same
		temp.Add ("");
		// Add a blank which shows as a guide line
		temp.Add ("");
		foreach (UnityEditor.EditorBuildSettingsScene scene in UnityEditor.EditorBuildSettings.scenes)
		{
			if (scene.enabled)
			{
				string name = scene.path.Substring(scene.path.LastIndexOf('/') + 1);
				name = name.Substring(0, name.Length - 6);
				temp.Add(name);
			}
		}
		return temp.ToArray();
	}
	
}





