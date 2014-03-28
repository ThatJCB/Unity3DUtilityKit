using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// NOTE: Drawing the line is UNRELIABLE.  It often vanishes!
/// 
/// It is supposed to draw a line spacer above or below the property and optionally
/// display text when the mouse is over the label.
/// =====================================================================================
/// Usage example:
/// 
/// [Divider()]	// Line above
/// public string RequiresSpace;
/// 
/// [Divider(true)]	// Line above
/// public string RequiresSpace;
/// 
/// [Divider(false)]	// Line below
/// public string RequiresSpace;
/// 
/// [Divider("Enter something appropriate")]	// Line above with tool tip
/// public string RequiresSpace;
/// 
/// [Divider(false, "Enter something appropriate")]	// Line below with tool tip
/// public string RequiresSpace;
/// 
/// =====================================================================================
/// </summary>
public class Divider : PropertyAttribute
{
	public string TipText = "";

	public bool SpaceAbove = true;

	/// <summary>
	/// Draw a line spacer above the property.
	/// </summary>
	public Divider()
	{
		TipText = "";
		SpaceAbove = true;
	}
	
	/// <summary>
	/// Draw a line spacer above the property and 
	/// display text when the mouse is over the label.
	/// </summary>
	public Divider(string toolTip)
	{
		TipText = toolTip;
		SpaceAbove = true;
	}
	
	/// <summary>
	/// Draw a line spacer above or below the property.
	/// </summary>
	public Divider(bool drawDividerAbove)
	{
		TipText = "";
		SpaceAbove = drawDividerAbove;
	}
	
	/// <summary>
	/// Draw a line spacer above or below the property and 
	/// display text when the mouse is over the label.
	/// </summary>
	public Divider(bool drawDividerAbove, string toolTip)
	{
		TipText = toolTip;
		SpaceAbove = drawDividerAbove;
	}

}





