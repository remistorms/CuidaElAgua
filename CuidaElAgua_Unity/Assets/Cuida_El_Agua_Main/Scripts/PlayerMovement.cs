using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

	public static PlayerMovement instance;
	public NavMeshAgent playerAgent;
	Camera mainCam;
	Ray myRay;
	RaycastHit myHit;
	public float distanceToTarget;

	void Awake(){
		instance = this;
		playerAgent = GetComponent<NavMeshAgent> ();
		mainCam = Camera.main;
	}

	//Decides what to do with hit
	void DetectHit(RaycastHit hit){


		switch (hit.collider.tag) {
			

			//Moves toward point
			case "walkable":
			Debug.Log ("Clicked object's tag = " + myHit.collider.tag + " name=" + myHit.collider.name);
			MovesTowardPoint (hit.point);
			break;

			//DO SOMETHING ELSE WITH INTERASCTABLE
			case "interactable":
			Debug.Log ("Clicked object's tag = " + myHit.collider.tag);
			MovesTowardPoint (hit.point);
			break;

			default:
			Debug.Log ("Clicked object's tag = unknown" + myHit.collider.name);
			break;
		}
	}

	void Update(){
		//Clicks and shoots a ray
		if (Input.GetMouseButtonDown(0)) {
			
			myRay = mainCam.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast(myRay, out myHit, 500)) {
				DetectHit (myHit);
				//Debug.Log ("raycast hitting" + myHit.collider.name);
			}
		}

		distanceToTarget = playerAgent.remainingDistance;
	}

	public void MovesTowardPoint(Vector3 point){
		//Places marker on point

		//Moves character towards point
		playerAgent.SetDestination(point);
	}

}
