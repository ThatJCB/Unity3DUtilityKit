using UnityEngine;
using System.Collections;

namespace UtilityKit
{
	/// <summary>
	/// Use to test attributes.
	/// 
	/// The the following thread for example properties that might cause issues:
	/// 	http://forum.unity3d.com/threads/182621-Inspector-Tooltips
	/// 
	/// The methods in this example work for all of the properties listed
	/// in the above thread.  Even the properties that others have not managed
	/// to get working.
	/// 
	/// This has been tested with Unity v4.3.4
	/// </summary>
	[ExecuteInEditMode]
	public class TestAttributes : MonoBehaviour 
	{
		public enum Fruit
		{
			Apple,
			Pear,
			Banana,
			Grape,
			Tomato
		}

		[ToolTip("Bool Tip")]
		public bool BoolExample = false;

		[TipBox("Bounds Help Message\nshown in a box under the item", "Bounds Tip")]
		public Bounds BoundsExample;

		[ToolTip("Colour Tip")]
		public Color ColourExample;

		[ToolTip("Enum Tip")]
		public Fruit EnumExample = Fruit.Apple;

		[ToolTip("Float Tip")]
		public float FloatExample = 2.5f;

		[ToolTip("Gradient Tip")]
		public Gradient GradientExample;

		[TipBox("Integer Help Message\nshown in a box above the item", "Integer Tip", true)]
		public int IntegerExample = 2;

		[ToolTip("Layer Mask Tip")]
		public LayerMask LayerMaskExample;

		[ToolTip("Rectangle Tip")]
		public Rect RectExample;

		[ToolTip("String Tip")]
		public string StringExample = "Test";

		[Divider(false, "Vector Tip which should be follow by a divider\nbut the line is unreliable!")]
		public Vector3 VectorExample;

		///////////////////////////////////////////////////////////////////////////
		// Basic unaltered versions
		//
		public bool BoolBasic = false;
		public Bounds BoundsBasic;
		public Color ColourBasic;
		public Fruit FruitBasic = Fruit.Apple;
		public float FloatBasic = 2.5f;
		public Gradient GradientBasic;
		public int IntegerBasic = 2;
		public LayerMask LayerMaskBasic;
		public Rect RectBasic;
		public string StringBasic = "Test";
		public Vector3 VectorBasic;
		//
		///////////////////////////////////////////////////////////////////////////

		private GUIStyle style = new GUIStyle();

		void OnGUI()
		{
			const int textWidth = 300;
			const int columnWidth = 300;

			float lineHeight = style.lineHeight;

			// Start at
			float x = Screen.width * 0.12f;
			float y = Screen.height * 0.12f;
			
			SetColor( Color.black );
			
			GUI.Label( new Rect( x, y, x + textWidth, y + 10 ), "Bool Example: " + BoolExample.ToString (), style );
			y += lineHeight;

			GUI.Label( new Rect( x, y, x + textWidth, y + 10 ), "Float Example: " + FloatExample, style );
			y += lineHeight;
			
			GUI.Label( new Rect( x, y, x + textWidth, y + 10 ), "Integer Example: " + IntegerExample, style );
			y += lineHeight;

			GUI.Label( new Rect( x, y, x + textWidth, y + 10 ), "Enum Example: " + EnumExample.ToString (), style );
			y += lineHeight;

			GUI.Label( new Rect( x, y, x + textWidth, y + 10 ), "String Example: " + StringExample, style );
			y += lineHeight;

			
		}

		private void SetColor( Color color )
		{
			style.normal.textColor = color;
		}
		

	}


}
