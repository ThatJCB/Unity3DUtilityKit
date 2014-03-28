using UnityEngine;
using System.Collections;

// TODO:
// Prove the values are being saved correctly
// Copy items to unchanged values.

namespace UtilityKit
{
	/// <summary>
	/// Use to test attributes.
	/// 
	/// The the following thread for example properties that might cause issues:
	/// 	http://forum.unity3d.com/threads/182621-Inspector-Tooltips
	/// </summary>
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
		public bool BoolItem = false;

		[TipBox("Bounds Help Message\nshown in a box under the item")]
		public Bounds BoundsItem;

		[ToolTip("Colour Tip")]
		public Color ColourItem;

		[ToolTip("Enum Tip")]
		public Fruit FruitItem = Fruit.Apple;

		[ToolTip("Float Tip")]
		public float FloatItem = 2.5f;

		[ToolTip("Gradient Tip")]
		public Gradient GradientItem;

		[TipBox("Integer Help Message\nshown in a box above the item", true)]
		public int IntegerItem = 2;

		[ToolTip("Layer Mask Tip")]
		public LayerMask LayerMaskItem;

		[ToolTip("Rectangle Tip")]
		public Rect RectItem;

		[ToolTip("String Tip")]
		public string StringItem = "Test";

		[ToolTip("Vector Tip")]
		public Vector3 VectorItem;

		///////////////////////////////////////////////////////////////////////////
		// Unchanged versions
		//
		public bool BoolUnchanged = false;
		public Bounds BoundsUnchanged;
		public Color ColourUnchanged;
		public Fruit FruitUnchanged = Fruit.Apple;
		public float FloatUnchanged = 2.5f;
		public Gradient GradientUnchanged;
		public int IntegerUnchanged = 2;
		public LayerMask LayerMaskUnchanged;
		public Rect RectUnchanged;
		public string StringUnchanged = "Test";
		public Vector3 VectorUnchanged;
		//
		///////////////////////////////////////////////////////////////////////////


	}

}
