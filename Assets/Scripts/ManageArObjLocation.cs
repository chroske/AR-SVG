using UnityEngine;
using System;
using Common;


public class ManageArObjLocation : MonoBehaviour {
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
			longitude =   ((objectLongitude - (decimal)Input.location.lastData.longitude) / Define.ONE_METER_LONGITUDE);
			latitude = (objectLatitude - (decimal)Input.location.lastData.latitude) / Define.ONE_METER_LATITUDO;

			//オブジェクトの距離が1キロ上離れてたら描画しない
			if (calculateDistance (longitude, latitude) < Define.LIMIT_DISTANCE) {
				//子オブジェクトのメソッド実行
				GameObject distanceText = gameObject.transform.FindChild ("CanvasWorldSpace/distanceText").gameObject;
				PrintObjectDistance pd = distanceText.GetComponent<PrintObjectDistance> ();
				pd.ChangeObjectDistance (longitude, latitude);

				int intLongitude = (int)Math.Floor (longitude / Define.REGULATE_VAL);
				int intLatitude = (int)Math.Floor (latitude / Define.REGULATE_VAL);

				transform.localPosition = new Vector3 (intLongitude, 0, intLatitude);
			} else {
				//オブジェクト削除

			}
		}
	}

	private int calculateDistance(decimal longitude,decimal latitude)
	{
		double Distance = Math.Sqrt (Math.Pow ((float)longitude, 2) + Math.Pow ((float)latitude, 2));
		return (int)Math.Floor(Distance);
	}
}
