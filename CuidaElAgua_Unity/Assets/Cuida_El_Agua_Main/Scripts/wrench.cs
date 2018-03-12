using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class wrench : MonoBehaviour {

	public float rotateSpeed = 5f;
	Vector3 originalPosition;
	public float height = 0.5f;
	public float hoverDuration = 2f;


	void Awake(){
		originalPosition = transform.position;
	
		iTween.MoveTo (transform.gameObject, iTween.Hash (
			"position", new Vector3(originalPosition.x, originalPosition.y + height, originalPosition.z ),
			"looptype", iTween.LoopType.pingPong,
			"easetype", iTween.EaseType.linear,
			"time", hoverDuration

		));
	}

	void FixedUpdate () {
		
		transform.RotateAround (Vector3.up, rotateSpeed * Time.deltaTime);
	}

}
