using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraSystem : MonoBehaviour {

	public static CameraSystem instance;
	public bool smoothTransition = false;

	public Camera mainCam;

	void Awake(){
		mainCam = Camera.main;
		instance = this;
	}

	public void SwitchCamPosition(Transform newPosition, float lerpTime){
		if (smoothTransition) {
			mainCam.transform.DOMove (newPosition.position, lerpTime);
		} else {
			mainCam.transform.position = newPosition.position;
		}
	}

	public void FadeOutCam(){
		//Make a fade later
	}
}
