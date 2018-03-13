using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IsoCamSystem : MonoBehaviour {

	public float distanceFromCenter;
	public float rotateSpeed = 0.2f;
	public Transform playerRef;
	public Camera isoCam;

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
	
		iTween.RotateAdd (this.gameObject, iTween.Hash (
			"y", 90,
			"easeType", iTween.EaseType.linear,
			"time", rotateSpeed
		));
	}

	public void RotateCamRight(){

		iTween.RotateAdd (this.gameObject, iTween.Hash (
			"y", -90,
			"easeType", iTween.EaseType.linear,
			"time", rotateSpeed
		));
	}

	void Awake(){
		playerRef = GameObject.FindGameObjectWithTag ("Player").transform;
		isoCam = Camera.main;
	}
}
