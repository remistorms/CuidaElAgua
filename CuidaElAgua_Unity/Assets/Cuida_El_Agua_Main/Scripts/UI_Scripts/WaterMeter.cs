using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class WaterMeter : MonoBehaviour {

	public static WaterMeter instance;
	public Slider waterSlider;
	public float totalWater = 0;
	public bool isFull = false;
	public bool callScientist = false;

	void Awake(){
		instance = this;
		waterSlider = GetComponent<Slider> ();
		waterSlider.value = 0f;
	}

	public void AddWater(int amount){
		
		Debug.Log ("Adding water to meter");
		float newAmount = waterSlider.value + amount / 100;

		waterSlider.DOValue (newAmount, 1);

		//float newValue = waterSlider.value + amount / 100;

		if (waterSlider.value >= 1) {
			//waterSlider.value = 1;
			isFull = true;
		}

	}

	void FixedUpdate(){
		if (waterSlider.value >= 1 && callScientist == false) {
			callScientist = true;
			isFull = true;
			Debug.Log ("Call scientist");
			UI_Manager.instance.ShowDialogueRoutine ();
			
		}
	}


}
