using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TuercaScript : MonoBehaviour {

	public float squeezeTime = 0.2f;
	public GameObject llave, fugaAgua, tuercaPivot;
	Vector3 originalScale, originalPosition;
	public SpriteRenderer splatSprite;


	// Use this for initialization
	void Awake () {
		//Gets references from original positions, locations and hides wrench
		originalScale = llave.transform.localScale;
		originalPosition = llave.transform.localPosition;
		llave.transform.localScale = Vector3.zero;
		//CLoseTuerca ();
	}

	public void CloseTuerca(){
	
		StartCoroutine (CloseTuercaRoutine ());
	}

	IEnumerator CloseTuercaRoutine(){

		//Makes wrench appear
		DOTween.To (
			()=> llave.transform.localScale,
			x=> llave.transform.localScale = x,
			originalScale,
			squeezeTime
		);
		yield return new WaitForSeconds (squeezeTime);

		//RotateTuerca
		RotateTuerca(60);
		yield return new WaitForSeconds (squeezeTime);

		//REPOSITION WRENCH
			//Remove Wrench
			DOTween.To (
				()=> llave.transform.localPosition,
				x=> llave.transform.localPosition = x,
				new Vector3(originalPosition.x, originalPosition.y, originalPosition.z -0.5f),
				squeezeTime
			);

			yield return new WaitForSeconds (squeezeTime * 2);

			//Rotate Wrench Pivot
			DOTween.To (
				()=> tuercaPivot.transform.localRotation,
				x=> tuercaPivot.transform.localRotation = x,
				new Vector3(-60, 0, 0),
				squeezeTime
			);
			yield return new WaitForSeconds (squeezeTime);

			//Place Wrench
			DOTween.To (
				()=> llave.transform.localPosition,
				x=> llave.transform.localPosition = x,
				new Vector3(originalPosition.x, originalPosition.y, originalPosition.z),
				squeezeTime
			);
			yield return new WaitForSeconds (squeezeTime);

		//RotateTuerca
		RotateTuerca(120);
		yield return new WaitForSeconds (squeezeTime);

		//Remove Wrench
		DOTween.To (
			()=> llave.transform.localPosition,
			x=> llave.transform.localPosition = x,
			new Vector3(originalPosition.x, originalPosition.y, originalPosition.z -0.5f),
			squeezeTime
		);

		//Makes wrench shrink
		DOTween.To (
			()=> llave.transform.localScale,
			x=> llave.transform.localScale = x,
			Vector3.zero,
			squeezeTime
		);

		yield return new WaitForSeconds (squeezeTime);

		fugaAgua.SetActive (false);

		//Fades splash
		DOTween.To (
			()=> splatSprite.color,
			x=> splatSprite.color = x,
			new Color(0,0,0,0),
			squeezeTime *3
		);

	}

	void RotateTuerca(float angle){
		DOTween.To (
			()=> transform.localRotation,
			x=> transform.localRotation = x,
			new Vector3(angle, 0, 0),
			squeezeTime
		);
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Space)) {
			CloseTuerca ();
		}
	}
}
