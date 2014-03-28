using UnityEngine;
using System.Collections;

/// <summary>
/// Creates a slider for floats and ints which only returns whole numbers
/// as the result.
/// 
/// Includes an optional tool tip.
/// </summary>
public class IntRange : PropertyAttribute
{
    public int min;
    public int max;

	public string ToolTip = "";

    public IntRange(int min, int max)
    {
        this.min = min;
        this.max = max;
    }

	public IntRange(int min, int max, string tipText)
	{
		this.min = min;
		this.max = max;

		ToolTip = tipText;
	}

}
