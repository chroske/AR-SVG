using UnityEngine;
using System.Collections.Generic;

public class ObjectTouchEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit)){
				GameObject obj = hit.collider.gameObject;
				Debug.Log("touchObject="+obj.name);
				PluginUniv.touchObject();
			}

			//オブジェクト作るテスト
			Dictionary<string, decimal> data = new Dictionary<string, decimal>();
			data.Add("id", 5);
			data.Add("longitude", (decimal)Input.location.lastData.longitude);
			data.Add("latitude", (decimal)Input.location.lastData.latitude);
//			data.Add("longitude", 139.702762m);
//			data.Add("latitude", 35.649982m);

			CreateObject createobject = new CreateObject();

			createobject.CreateArObject(data);
		}
	}
}