using UnityEngine;
using System;



public class MoveCameraAction : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}

	float Atan2 (float f, float f2)
	{
		throw new NotImplementedException ();
	}
		
	// Update is called once per frame
	void Update () {
		//katamuki get
		Quaternion gyro = Input.gyro.attitude;

		float pitch = Mathf.Asin (2 * gyro.w * gyro.y - 2 * gyro.x * gyro.z);
		float roll = Mathf.Atan2 (2 * gyro.y * gyro.z + 2 * gyro.w * gyro.x, -gyro.w*gyro.w + gyro.x*gyro.x + gyro.y*gyro.y - gyro.z*gyro.z);
	
		Vector3 angle = new Vector3(roll*Mathf.Rad2Deg,0,0);

		transform.localRotation = Quaternion.Euler(angle) * Quaternion.Euler(270f, 0, 0);
	}
}
