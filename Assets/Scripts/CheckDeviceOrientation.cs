using UnityEngine;
using System.Collections;

public class CheckDeviceOrientation : MonoBehaviour {

	public DeviceOrientation devOri;

	// Use this for initialization
	void Start () {
		devOri = Input.deviceOrientation;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.deviceOrientation != devOri) {
			PluginUniv.checkQpaque();
			devOri = Input.deviceOrientation;
		}
			
	}
}
