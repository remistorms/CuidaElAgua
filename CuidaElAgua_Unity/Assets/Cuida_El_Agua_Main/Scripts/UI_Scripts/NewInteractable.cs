using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NewInteractable : MonoBehaviour {

	public bool requiresItem = false;
	public int requiredItem;
	public GameObject raycastBlocker;
	//Button Prefab to instantiate
	public RectTransform interactableButton;
	//Main canvas for interactables
	RectTransform interactablesCanvas;
	//Distance from object to player to show button
	float interactionDistance = 3.0f;
	//PLayer reference
	Transform playerRef;
	//CamReference
	Camera mainCam;

	//Variables
	Vector3 myPositionOnScreen;
	float distanceFromPlayer;
	float interactableHeightOffset = 80f;
	//public RectTransform buttonRect;


	void Awake(){
		//Gets a cam ref
		mainCam = Camera.main;
		//Gets a player reference
		playerRef = GameObject.FindGameObjectWithTag("Player").transform;
		//Gets interactable canvas
		interactablesCanvas = GameObject.FindGameObjectWithTag("interactablesCanvas").GetComponent<RectTransform>();
		//Makes the raycaster blocker invisible
		raycastBlocker.GetComponent<MeshRenderer> ().enabled = false;
		raycastBlocker.tag = "interactable";
	}

	void LateUpdate(){

		//Gets position on screen based on object in world, this is pretty fucking amazing actually
		myPositionOnScreen = mainCam.WorldToScreenPoint (this.transform.position);
		interactableButton.position = new Vector2 (myPositionOnScreen.x, myPositionOnScreen.y + interactableHeightOffset);
		raycastBlocker.transform.position = new Vector3 (transform.position.x, transform.position.y + 1.69f, transform.position.z);

		//Gets distance from player
		distanceFromPlayer = Vector3.Distance (this.transform.position, playerRef.position);

		//Checks if can interact and if player has required item in inventory
		if (interactableButton.GetComponent<InteractableButton>().canInteract) 
		{
			//DOESNT REQUIRE ITEM AND IS CLOSE ENOUGH
			if (!requiresItem && distanceFromPlayer <= interactionDistance ) {
					ShowUI ();
				} 

			//REQUIRES ITEM ADN HAS ITEM
			else if (requiresItem && PlayerInventory.instance.obtainedItemsIDS.Contains(requiredItem) && distanceFromPlayer <= interactionDistance) {
					ShowUI ();
			}

			else {
				//Debug.Log ("Cant interact");
				HideUI ();
			}
			}



	}

	void ShowUI(){
		//Check if player requires item
		//Debug.Log ("SHOW UI BUTTON");
		interactableButton.DOScale (Vector3.one, 0.5f);
		raycastBlocker.SetActive (true);
	}

	void HideUI(){
			interactableButton.DOScale (Vector3.zero, 0.5f);
		raycastBlocker.SetActive (false);
	}

}
