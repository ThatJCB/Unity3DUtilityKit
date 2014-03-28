using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Display a tool tip on mouse over the label.
/// 
/// =====================================================================================
/// Usage example:
/// 
/// [ToolTip("Enter something appropriate")]
/// public string RequiresExplanation;
/// 
/// =====================================================================================
/// </summary>
public class ToolTip : PropertyAttribute
{
	public string TipText = "";

    /// <summary>
	/// Display text when the mouse is over the label.
	/// </summary>
    public ToolTip(string message)
    {
		TipText = message;
    }

}





