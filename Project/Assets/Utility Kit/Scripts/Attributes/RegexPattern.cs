using UnityEngine;
using System.Collections;

/// <summary>
/// Regex attribute.
/// 
/// =====================================================================================
/// Usage example:
/// 
/// [Regex (@"^(?:\d{1,3}\.){3}\d{1,3}$", "Invalid IP address!\nExample: '127.0.0.1'")]
/// public string serverAddress = "192.168.0.1";
/// 
/// =====================================================================================
/// 
/// Taken from the example from the following blog:
/// 	http://blogs.unity3d.com/2012/09/07/property-drawers-in-unity-4/
/// </summary>
public class RegexPattern : PropertyAttribute 
{
	public readonly string pattern;
	public readonly string helpMessage;

	public RegexPattern (string pattern, string helpMessage) 
	{
		this.pattern = pattern;
		this.helpMessage = helpMessage;
	}
}