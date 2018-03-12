using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraSystem : MonoBehaviour {

	public static CameraSystem instance;

	public Camera mainCam;

	void Awake(){
		mainCam = Camera.main;
		instance = this;
	}

	public void SwitchCamPosition(Transform newPosition, float lerpTime){
	
		mainCam.transform.DOMove (newPosition.position, lerpTime);
	}

	public void FadeOutCam(){
		//Make a fade later
	}
}
