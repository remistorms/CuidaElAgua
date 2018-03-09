using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

	[Header("ROTATION VARIABLES")]
	public float speed = 5.0f;
	public Transform target;
	public Transform x_axis;

	[Header("ZOOM VARIABLES")]
	public float minFov = 15f;
	public float maxFov = 90f;
	public float sensitivity = 10f;

	void Update () {

		CamYRotation ();
		//Zoom ();
			
	}


	void CamYRotation(){
		if (Input.GetMouseButton(0)) {
			transform.LookAt(target);
			transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X")*speed);

		}
	}

	void Zoom () {
		float fov = Camera.main.fieldOfView;
		fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		fov = Mathf.Clamp(fov, minFov, maxFov);
		Camera.main.fieldOfView = fov;
	}

}
