using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTriggerScript : MonoBehaviour {

	Camera tempCam;
	Transform camTransform;
	public float camTransitionTime;

	void Awake(){
		InitializeTrigger ();
	}

	void InitializeTrigger(){
		//Makes trigger invisible
		GetComponent<MeshRenderer>().enabled = false;
		//makes trigger a trigger
		GetComponent<Collider>().isTrigger = true;
		//Gets transform referenc fro temp cam
		tempCam = GetComponentInChildren<Camera>();
		camTransform = tempCam.transform;
		//Disables cam
		tempCam.gameObject.SetActive(false);

	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			CameraSystem.instance.SwitchCamPosition (camTransform, camTransitionTime);
		}
	}
}
