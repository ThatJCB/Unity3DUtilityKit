using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Draw a spacer above or below the property and optionally
/// displays a heading under the line and tool tip
/// text when the mouse is over the label.
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
/// [Divider(true, "", "Enter something appropriate")]	// Line above with tool tip
/// public string RequiresSpace;
/// 
/// [Divider(false, "Heading", "Enter something appropriate")]	// Line below with tool tip and heading
/// public string RequiresSpace;
/// 
/// =====================================================================================
/// </summary>
public class Divider : PropertyAttribute
{
	public string Heading = "";
	public string TipText = "";

	public bool SpaceAbove = true;

	/// <summary>
	/// Draw a spacer above the property.
	/// </summary>
	public Divider()
	{
		Heading = "";
		TipText = "";
		SpaceAbove = true;
	}
	
	/// <summary>
	/// Draw a spacer above the property and 
	/// display text when the mouse is over the label.
	/// </summary>
	public Divider(string toolTip)
	{
		Heading = "";
		TipText = toolTip;
		SpaceAbove = true;
	}
	
	/// <summary>
	/// Draw a spacer above or below the property.
	/// </summary>
	public Divider(bool drawDividerAbove)
	{
		Heading = "";
		TipText = "";
		SpaceAbove = drawDividerAbove;
	}
	
	/// <summary>
	/// Draw a spacer above or below the property and optional
	/// heading and tool tip.
	/// </summary>
	public Divider(bool drawDividerAbove, string titleText, string toolTip)
	{
		Heading = titleText;
		TipText = toolTip;
		SpaceAbove = drawDividerAbove;
	}

}





