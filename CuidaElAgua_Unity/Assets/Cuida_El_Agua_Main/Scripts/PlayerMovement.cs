using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

	NavMeshAgent playerAgent;
	Camera mainCam;
	Ray myRay;
	RaycastHit myHit;

	void Awake(){
		playerAgent = GetComponent<NavMeshAgent> ();
		mainCam = Camera.main;
	}

	//Decides what to do with hit
	void DetectHit(RaycastHit hit){
		switch (hit.collider.tag) {

			//Moves toward point
			case "walkable":
			MovesTowardPoint (hit.point);
			break;

			//DO SOMETHING ELSE WITH INTERASCTABLE
			case "interactable":
			break;

		default:
			break;
		}
	}

	void Update(){
		//Clicks and shoots a ray
		if (Input.GetMouseButtonDown(0)) {
			
			myRay = mainCam.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast(myRay, out myHit)) {
				DetectHit (myHit);
			}
		}
	}

	void MovesTowardPoint(Vector3 point){
		//Places marker on point

		//Moves character towards point
		playerAgent.SetDestination(point);
	}
}
