using UnityEngine;

/// <summary>
/// Prepares variables to be used by PopupDrawer.
/// 
/// =====================================================================================
/// Usage example:
/// 
/// [Popup ("Human/Local", "Human/Network", "AI/Easy", "AI/Normal", "AI/Hard")]
/// public string controller;
/// 
/// =====================================================================================
/// 
/// Taken from the example from the following post:
/// 	http://forum.unity3d.com/threads/150337-PropertyDrawers-for-easy-Inspector-customization/page2
/// </summary>
public class PopupList : PropertyAttribute
{
    public string[] list;
    public object variableType;

    /// <summary>
    /// Makes necessary operations to prepare the variables for later use by PopupDrawer.
    /// </summary>
    /// <param name="list">Parameters array to be analized and assigned.</param>
    public PopupList(params object[] list)
    {
        if (IsVariablesTypeConsistent(list) && AssignVariableType(list[0]))
        {
            this.list = new string[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                this.list[i] = list[i].ToString();
            }
        }
        else
        {
            return;
        }

    }

    /// <summary>
    /// Checks if variable type is valid, and assignes the variable type to the proper variable.
    /// </summary>
    /// <param name="variable">Object to get type from.</param>
    /// <returns>Returns true if variable type is valid, and false if it isn't.</returns>
    private bool AssignVariableType(object variable)
    {
        if (variable.GetType() == typeof(int))
        {
            variableType = typeof(int[]);
            return true;
        }
        else if (variable.GetType() == typeof(float))
        {
            variableType = typeof(float[]);
            return true;
        }
        else if (variable.GetType() == typeof(double))
        {
            Debug.LogWarning("Popup Drawer doesn't properly support double type, for float variables please use 'f' at the end of each value.");
            variableType = typeof(float[]);
            return true;
        }
        else if (variable.GetType() == typeof(string))
        {
            variableType = typeof(string[]);
            return true;
        }
        else
        {
            Debug.LogError("Popup Property Drawer doesn't support " + variable.GetType() + " this type of variable");
            return false;
        }
    }

    /// <summary>
    /// Checks to see if there is only one variable type in the given value.
    /// </summary>
    /// <param name="list">Array of variables to be checked.</param>
    /// <returns>True if there is only one type, false if there is 2 or more.</returns>
    private bool IsVariablesTypeConsistent(object[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            if (i == 0)
            {
                variableType = list[i].GetType();
            }
            else if (variableType != list[i].GetType())
            {
                Debug.LogError("Popup Property Drawer can only contain one type per variable");
                return false;
            }
        }

        return true;
    }

}





