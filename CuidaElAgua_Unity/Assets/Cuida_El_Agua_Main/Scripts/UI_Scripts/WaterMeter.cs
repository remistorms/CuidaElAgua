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

	void Awake(){
		instance = this;
		waterSlider = GetComponent<Slider> ();
		waterSlider.value = 0f;
	}

	public void AddWater(int amount){
		Debug.Log ("Adding water to meter");
		float newValue = waterSlider.value + amount / 100;

		waterSlider.value = newValue;


	}

	public void UpdateValueTween(float value){

	}
}
