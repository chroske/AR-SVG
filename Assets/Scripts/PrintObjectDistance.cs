using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PrintObjectDistance : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	}

	public void ChangeObjectDistance (decimal longitude,decimal latitude) {
		double Distance = Math.Sqrt (Math.Pow ((float)longitude, 2) + Math.Pow ((float)latitude, 2));
		//double Distance = Math.Sqrt (test);

		Text myText = GetComponent<Text> ();
		int printText = (int)Math.Floor(Distance);

		myText.text = printText.ToString();
	}
}
