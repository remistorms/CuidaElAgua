using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TuercaScript : Interactable {

	public float squeezeTime = 0.2f;
	public GameObject tuerca, llave,llavePivot;
	public SpriteRenderer[] stains;
	public GameObject[] fugas;
	Vector3 originalScale;



	void Awake(){
		base.Initialize ();
		//InvokeRepeating ("RotateTuerca", 0, squeezeTime *2);
		originalScale = llave.transform.localScale;
		llave.transform.localScale = Vector3.zero;



	}

	public override void Update ()
	{
		base.Update ();
		buttonCanvas.LookAt (2 * transform.position - Camera.main.transform.position);
		//Check if player has required item in inventory
		if ((Vector3.Distance(PlayerMovement.instance.gameObject.transform.position, this.gameObject.transform.position) <= interactionDistance) && (canInteract == true)) {
			ShowInteractionIcon ();
		}
	}

	public override void Interact ()
	{
		base.Interact ();
		RotateTuerca (3);
	}

	void RotateTuerca(int times){
		StartCoroutine (RotateTuercaRoutine (times));
	}




	IEnumerator RotateTuercaRoutine(int loopCycle){

		base.HideInteractionIcon ();
		canInteract = false;

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
