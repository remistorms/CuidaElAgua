using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IsoCamSystem : MonoBehaviour {

	public float distanceFromCenter;
	public float rotateSpeed = 0.2f;
	public Transform playerRef;
	public Camera isoCam;
	public bool canRotate = true;

	void Update(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			RotateCamLeft ();	
		}

		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			RotateCamRight ();	
		}
	}

	void LateUpdate(){
	//Check player distance from center and zoom in accordingly
		//distanceFromCenter = Vector3.Distance(playerRef.position, Vector3.zero);

		//isoCam.orthographicSize = distanceFromCenter * 1.5f;
	}

	public void RotateCamLeft(){

		if (canRotate) {
			canRotate = false;

			iTween.RotateAdd (this.gameObject, iTween.Hash (
				"y", 90,
				"easeType", iTween.EaseType.linear,
				"time", rotateSpeed,
				"oncompletetarget", this.gameObject,
				"oncomplete", "RotateAgain"
			));
		}

	}

	public void RotateCamRight(){

		if (canRotate) {
			canRotate = false;
			iTween.RotateAdd (this.gameObject, iTween.Hash (
				"y", -90,
				"easeType", iTween.EaseType.linear,
				"time", rotateSpeed,
				"oncompletetarget", this.gameObject,
				"oncomplete", "RotateAgain"
			));
		}

	}

	void Awake(){
		playerRef = GameObject.FindGameObjectWithTag ("Player").transform;
		isoCam = Camera.main;
	}

	public void RotateAgain(){
		canRotate = true;
	}
}
