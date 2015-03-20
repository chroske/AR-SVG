using UnityEngine;
using System.Collections;

public class WebCameScript : MonoBehaviour {
	public int Width = 1136;//1920;
	public int Height = 640;//1080;
	public int FPS = 60;//30;
	
	void Start () {
		//var euler = transform.localRotation.eulerAngles;
		//transform.localRotation = Quaternion.Euler( euler.x, euler.y, euler.z - 90 );
		var devices = WebCamTexture.devices;
		if (devices.Length > 0)
		{
			var webcamTexture = new WebCamTexture(Width, Height, FPS);

			renderer.material.mainTexture = webcamTexture;
			webcamTexture.Play();
		}else
		{
			Debug.Log("Webカメラが検出できませんでした");
			return;
		}
	}

//	public GameObject Quad;
//
//	public int camWidth_px = 1280;
//	public int camHeight_px = 720;
//
//	WebCamTexture webcamTexture;
//
//	void Start () {
//
//		var devices = WebCamTexture.devices;
//
//		if (devices.Length > 0)
//		{
//			var euler = transform.localRotation.eulerAngles;
//			webcamTexture = new WebCamTexture(camWidth_px,camHeight_px);
//
//			//iPhone,Androidの場合はカメラの向きを縦にする
//			if(Application.platform == RuntimePlatform.IPhonePlayer||Application.platform == RuntimePlatform.Android){
//				transform.localRotation = Quaternion.Euler( euler.x, euler.y, euler.z - 90 );
//			}
//
//			renderer.material.mainTexture = webcamTexture;
//			webcamTexture.Play();
//
//		}else
//		{
//			Debug.Log("Webカメラが検出できませんでした");
//			return;
//		}
//	}
//
//	//Sceneを変更する場合にカメラを止める
//	public void EndCam(){
//		webcamTexture.Stop ();
//	}
}
