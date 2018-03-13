using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NewInteractable : MonoBehaviour {

	//Button Prefab to instantiate
	public RectTransform interactableButton;
	//Main canvas for interactables
	public RectTransform interactablesCanvas;
	//Distance from object to player to show button
	public float interactionDistance;
	//PLayer reference
	Transform playerRef;
	//CamReference
	Camera mainCam;

	//Variables
	public Vector3 myPositionOnScreen;
	public float distanceFromPlayer;
	public float interactableHeightOffset = 128f;
	RectTransform buttonRect;


	void Awake(){
		//Gets a cam ref
		mainCam = Camera.main;
		//Gets a player reference
		playerRef = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void LateUpdate(){

		myPositionOnScreen = mainCam.WorldToScreenPoint (this.transform.position);

		interactableButton.position = new Vector2 (myPositionOnScreen.x, myPositionOnScreen.y + interactableHeightOffset);

		distanceFromPlayer = Vector3.Distance (this.transform.position, playerRef.position);
		if (distanceFromPlayer <= interactionDistance) {
			Debug.Log ("Player is close enought to interact with " + this.gameObject.name);
		}
	}
}
