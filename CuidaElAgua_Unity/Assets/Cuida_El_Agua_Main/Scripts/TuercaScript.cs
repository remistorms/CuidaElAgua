using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TuercaScript : MonoBehaviour {

	public float squeezeTime = 0.2f;
	public GameObject tuerca, llave,llavePivot;
	public SpriteRenderer[] stains;
	public GameObject[] fugas;
	Vector3 originalScale;

	void Awake(){
		//InvokeRepeating ("RotateTuerca", 0, squeezeTime *2);
		originalScale = llave.transform.localScale;
		llave.transform.localScale = Vector3.zero;
		//RotateTuerca(5);
	}

	void Update(){
	
		if (Input.GetKeyDown(KeyCode.Space)) {
			RotateTuerca (5);
		}
	}

	void RotateTuerca(int times){
		StartCoroutine (RotateTuercaRoutine (times));
	}

	IEnumerator RotateTuercaRoutine(int loopCycle){

		//Scale llave to make it appear
		DOTween.To (
			()=> llave.transform.localScale,
			x=> llave.transform.localScale = x,
			originalScale,
			0.5f
		);
		yield return new WaitForSeconds (0.5f);

		for (int i = 0; i < loopCycle; i++) {
			//Rotates tuerca 60 degrees
			iTween.RotateAdd (tuerca.gameObject, iTween.Hash (
				"x", 60,
				"time", squeezeTime,
				"easeType", iTween.EaseType.linear,
				"islocal", true
			));
			//Rotates llave 60 degrees
			iTween.RotateAdd (llavePivot.gameObject, iTween.Hash (
				"x", 60,
				"time", squeezeTime,
				"easeType", iTween.EaseType.linear,
				"islocal", true
			));

			yield return new WaitForSeconds (squeezeTime);

			//Rotates llave -60 degrees
			iTween.RotateAdd (llavePivot.gameObject, iTween.Hash (
				"x", -60,
				"time", squeezeTime,
				"easeType", iTween.EaseType.linear,
				"islocal", true
			));

			yield return new WaitForSeconds (squeezeTime);
		}
		DOTween.To (
			()=> llave.transform.localScale,
			x=> llave.transform.localScale = x,
			Vector3.zero,
			0.5f
		);

		foreach (var item in fugas) {
			item.SetActive (false);
		}

		foreach (var item in stains) {
			DOTween.To (
				()=> item.color,
				x=> item.color = x,
				new Color(0,0,0,0),
				2f
			);
		}

	}
	
}
