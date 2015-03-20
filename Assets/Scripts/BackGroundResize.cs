using UnityEngine;

public class BackGroundResize : MonoBehaviour
{
	public Camera BackGroundCamera;

	void Start ()
	{
		BackGroundCamera = GameObject.Find("BackGroundCamera").GetComponent<Camera>();
		UpdateScale ();
	}

	[ContextMenu("execute")]
	void UpdateScale ()
	{
		if (BackGroundCamera == null) {
			BackGroundCamera = Camera.main;
		}

		float height = BackGroundCamera.orthographicSize * 2;
		float width = height * BackGroundCamera.aspect;

		transform.localScale = new Vector3 (width, height, 0);
	}
}