using UnityEngine;
using System;


public class ManageArObjLocation : MonoBehaviour {

	//経度
	decimal OneMeterlongitude = 0.000010966382364m;
	//緯度
	decimal OneMeterlatitude = 0.000008983148616m;

	public decimal objectLongitude;
	public decimal objectLatitude;

	public decimal longitude;
	public decimal latitude;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.location.status == LocationServiceStatus.Failed ) 
		{ 
			Debug.Log( "Unable to determine device location" ); 
		} 
		else 
		{
			//現在位置を取得して相対位置を修正
			longitude =   ((objectLongitude - (decimal)Input.location.lastData.longitude) / OneMeterlongitude);
			latitude = (objectLatitude - (decimal)Input.location.lastData.latitude) / OneMeterlatitude;

			//子オブジェクトのメソッド実行
			GameObject distanceText = gameObject.transform.FindChild("CanvasWorldSpace/distanceText").gameObject;
			PrintObjectDistance pd = distanceText.GetComponent<PrintObjectDistance> ();
			pd.ChangeObjectDistance(longitude,latitude);

			int regulateVal = 25;

			int intLongitude = (int)Math.Floor (longitude / regulateVal);
			int intLatitude = (int)Math.Floor (latitude / regulateVal);

			transform.localPosition = new Vector3(intLongitude, 0, intLatitude);
		}
	}
}
