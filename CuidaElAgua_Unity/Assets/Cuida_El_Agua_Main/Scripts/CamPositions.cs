using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamPositions : MonoBehaviour {

	Transform playerRef;
	public Vector3 followOffset;

	void Awake(){
		playerRef = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void LateUpdate(){
		//Looks at player + offset 
		Vector3 lookTarget = new Vector3 (playerRef.transform.position.x + followOffset.x,
			                     playerRef.transform.position.y + followOffset.y,
			                     playerRef.transform.position.z + followOffset.z);
		transform.LookAt (lookTarget);
	}
}
