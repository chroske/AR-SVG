using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Common;

public class CreateObject : MonoBehaviour {
	public GameObject cube;


	//public Dictionary<int, string> arObjData = new Dictionary<int, string>();

	// 位置情報の取得開始。 
	void Start() 
	{	
//		//ARオブジェクトデータ　サーバから取ってくるもの
//		Dictionary<int, string> arObjData = new Dictionary<int, string>();
//		arObjData.Add(1, "SD_unitychan_generic");
//		arObjData.Add(2, "ArObject1");
//		arObjData.Add(3, "ArObject2");
//		arObjData.Add(4, "ArObject3");
//		arObjData.Add(5, "ArObject4");

		List<Dictionary<string, decimal>> objectLocationDataList = new List<Dictionary<string, decimal>>();

		//サブウェイ
		Dictionary<string, decimal> data = new Dictionary<string, decimal>();
		data.Add("id", 1);
		data.Add("longitude", 139.702762m);
		data.Add("latitude", 35.649982m);
		objectLocationDataList.Add(data);

		//ジム
		Dictionary<string, decimal> data2 = new Dictionary<string, decimal>();
		data2.Add("id", 2);
		data2.Add("longitude", 139.70172430099777m);
		data2.Add("latitude", 35.6504891900474m);
		objectLocationDataList.Add(data2);

		//富士そば
		Dictionary<string, decimal> data3 = new Dictionary<string, decimal>();
		data3.Add("id", 3);
		data3.Add("longitude", 139.70336178960136m);
		data3.Add("latitude", 35.651004306552444m);
		objectLocationDataList.Add(data3);

		//セブンイレブン
		Dictionary<string, decimal> data4 = new Dictionary<string, decimal>();
		data4.Add("id", 4);
		data4.Add("longitude", 139.70323572577766m);
		data4.Add("latitude", 35.65056622275544m);
		objectLocationDataList.Add(data4);


		//ここまではjsonで取ってくるはずのデータ

		//obj生成
		objectLocationDataList.ForEach(CreateArObject);

		Input.location.Start (); 
		StartWait (); 
		
		Debug.Log ("service initialize --> success"); 
	}

	public void CreateArObject(Dictionary<string, decimal> data){
		if (Input.location.status == LocationServiceStatus.Failed) {
			Debug.Log ("Unable to determine device location"); 
		} else {
			//ARオブジェクトデータ　サーバから取ってくるもの
			Dictionary<int, string> arObjData = new Dictionary<int, string>();
			arObjData.Add(1, "ArObject1b"/*"SD_unitychan_generic"*/);
			arObjData.Add(2, "ArObject7");
			arObjData.Add(3, "ArObject2b");
			arObjData.Add(4, "ArObject3b");
			arObjData.Add(5, "ArObject5b");


			//自分の座標との相対位置位置計算
			decimal longitude =   (data["longitude"] - (decimal)Input.location.lastData.longitude) / Define.ONE_METER_LONGITUDE;
			decimal latitude = (data["latitude"] - (decimal)Input.location.lastData.latitude) / Define.ONE_METER_LATITUDO;

			Debug.Log ("id="+arObjData[(int)data["id"]]);
			cube = Instantiate(Resources.Load(arObjData[(int)data["id"]])) as GameObject;

			//親子関係
			GameObject compass = GameObject.Find("Compass");
			cube.transform.parent = compass.transform;

			int intLongitude = (int)Math.Floor (longitude / Define.REGULATE_VAL);
			int intLatitude = (int)Math.Floor (latitude / Define.REGULATE_VAL);

			Debug.Log ("intLongitude="+intLongitude); 
			Debug.Log ("intLatitude="+intLatitude); 
			//位置を代入
			cube.transform.localPosition = new Vector3(intLongitude, 0, intLatitude);

			ManageArObjLocation maol = cube.GetComponent<ManageArObjLocation> ();
			maol.objectLongitude = data["longitude"];
			maol.objectLatitude = data["latitude"];

		}
	}




	// 端末の位置情報が有効か調べる。 
	public static bool IsEable() 
	{ 
		if ( !Input.location.isEnabledByUser ) 
		{ 
			Debug.Log("isEnabledByUser --> NO"); 
			return false; 
		} 
		Debug.Log("isEnabledByUser --> OK"); 
		return true; 
	}

	// 位置情報の取得終了。 
	public static void End() 
	{ 
		Input.location.Stop (); 
		
		Debug.Log ("service finalize --> success"); 
	} 
	
	// 初期化できるまで待つ 
	static IEnumerator StartWait() 
	{ 
		while( Input.location.status == LocationServiceStatus.Initializing ) 
		{ 
			yield return new WaitForSeconds(1); 
		} 
	} 
	
	// 更新処理。 
	void Update() 
	{ 

	}
}
