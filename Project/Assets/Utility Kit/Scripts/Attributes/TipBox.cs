using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// NICE TO HAVE:
// Word wrap the text.
// This would have to be calculated manually after the column width
// has been calculated.
// Strip out existing \n's and add in where needed.

/// <summary>
/// Display a text box above or below the value.
/// 
/// =====================================================================================
/// Usage example:
/// 
/// [TipBox("Enter something appropriate")]
/// public string RequiresExplanation;
/// 
/// [TipBox("Enter something appropriate", true)]	// Show the message above the text
/// public string RequiresExplanation;
/// 
/// =====================================================================================
/// </summary>
public class TipBox : PropertyAttribute
{
	/// <summary>
	/// The text to be drawn in a fixed position box.
	/// </summary>
	public string BoxedText = "";

	/// <summary>
	/// The text to show in the floating tool tip.
	/// </summary>
	public string TipText = "";

    public string[] list;

	public bool ShowTipAbove = false;

    /// <summary>
	/// Display a text box under the value.
	/// </summary>
    public TipBox(string message)
    {
		ShowTipAbove = false;
		BoxedText = message;
		TipText = "";
    }

	/// <summary>
	/// Display a text box below the value and
	/// include a floating tool tip.
	/// </summary>
	public TipBox(string message, string toolTip)
	{
		ShowTipAbove = false;
		BoxedText = message;
		TipText = toolTip;
	}
	
	/// <summary>
	/// Display a text box above the value if set to true.
	/// </summary>
	public TipBox(string message, bool showTextAbove)
	{
		ShowTipAbove = showTextAbove;
		BoxedText = message;
		TipText = "";
	}

	/// <summary>
	/// Display a text box above the value if set to true and
	/// include a floating tool tip.
	/// </summary>
	public TipBox(string message, string toolTip, bool showTextAbove)
	{
		ShowTipAbove = showTextAbove;
		BoxedText = message;
		TipText = toolTip;
	}
	
}





