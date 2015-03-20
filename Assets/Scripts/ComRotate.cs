using UnityEngine;
using System.Collections;

public class ComRotate : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Input.compass.enabled = true;
	}

	// Update is called once per frame
	void Update () {
		Input.compass.enabled = true;
		transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
	}
}