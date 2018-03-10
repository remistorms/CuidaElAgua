﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ItemsMenu : MonoBehaviour {

	public float transitionSpeed = 0.1f;

	RectTransform myRect;
	public List<RectTransform> itemButtons;
	int totalButtons;
	float orignalWidth;


	void Start(){
		InitialSetup ();
	}


	public void OpenMenu(){
		//Dissables button
		GetComponent<Button>().enabled = false;
		GetComponent<Button> ().interactable = false;

		//Scale the container to fit all buttons
		DOTween.To(
			()=> myRect.sizeDelta,
			x=> myRect.sizeDelta = x,
			new Vector2(orignalWidth * totalButtons, myRect.sizeDelta.y),
			transitionSpeed
		);

		//Enables all buttons
		foreach (var item in itemButtons) {
			item.transform.gameObject.SetActive (true);
			item.GetComponent<Button> ().enabled = true;
			item.GetComponent<Button> ().interactable = true;
		}
	}

	public void CloseMenu(int selectedButtonIndex){


		//Enables button
		GetComponent<Button>().enabled = true;
		GetComponent<Button> ().interactable = true;

		//Scale the container to fit all buttons
		DOTween.To(
			()=> myRect.sizeDelta,
			x=> myRect.sizeDelta = x,
			new Vector2(orignalWidth, myRect.sizeDelta.y),
			transitionSpeed
		);

		//Disables all buttons
		foreach (var item in itemButtons) {
			item.transform.gameObject.SetActive (false);
			item.GetComponent<Button> ().enabled = false;
			item.GetComponent<Button> ().interactable = false;
		}

		//Enables whichever button was pressed
		itemButtons [selectedButtonIndex].transform.gameObject.SetActive (true);
	}




	void InitialSetup(){

		//Holds a reference to itself, wow...
		myRect = this.GetComponent<RectTransform> ();
	
		//Gets original delta X (Width)
		orignalWidth = myRect.sizeDelta.x;
	
		//Gets all buttons inside
		for (int i = 0; i < myRect.transform.childCount; i++) 
		{
			itemButtons.Add (myRect.transform.GetChild (i).GetComponent<RectTransform>());
		}
			
		//Deactivate Buttons
		foreach (var item in itemButtons) {
			item.transform.gameObject.SetActive (false);
		}

		//Activate first item
		itemButtons[0].transform.gameObject.SetActive(true);

		//saves the amount of buttons
		totalButtons = itemButtons.Count;

	} // SETUPS THE BUTTONS FOR THE FRIST TIME

}