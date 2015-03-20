using UnityEngine;
using System.Collections;

public class StartArSence : MonoBehaviour {

	public Camera MainCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ClickTest () {
		MainCamera = GameObject.Find("Top Main Camera").GetComponent<Camera>();
		MainCamera.enabled = false;

		//Application.LoadLevel("ar_camera");
		//Application.LoadLevelAdditive("ar_camera");
	}
}
