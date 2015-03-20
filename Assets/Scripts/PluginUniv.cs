using UnityEngine;
using System.Runtime.InteropServices;

public class PluginUniv { 
	[DllImport("__Internal")]
	private static extern void _startCamera();
	public static void startCamera() {
		if (Application.platform != RuntimePlatform.OSXEditor) {
			_startCamera();
		}
	}

	[DllImport("__Internal")]
	private static extern void _touchObject();
	public static void touchObject() {
		if (Application.platform != RuntimePlatform.OSXEditor) {
			_touchObject();
		}
	}

	[DllImport("__Internal")]
	private static extern void _checkQpaque();
	public static void checkQpaque() {
		if (Application.platform != RuntimePlatform.OSXEditor) {
			_checkQpaque();
		}
	}
}