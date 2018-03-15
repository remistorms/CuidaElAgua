using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BreakCrateAndGetKey : MonoBehaviour {

	bool isShaking = false;
	public float shakeSpeed = 10;
	public GameObject houseKeyGO;


	public void DesintegrateCrate(){
		StartCoroutine (DestroyRoutine ());
	}

	IEnumerator DestroyRoutine(){
		isShaking = true;
		yield return new WaitForSeconds (1);
		transform.DOScale (Vector3.zero, 0.2f);
		yield return new WaitForSeconds (0.2f);
		houseKeyGO.GetComponent<NewInteractable> ().enabled = true;
		isShaking = false;
	}


	void Update(){

		if (isShaking) {
			float myX = Mathf.Sin (Time.time * shakeSpeed);
			float myZ= Mathf.Sin (Time.time * -shakeSpeed);
			myX = myX * 0.1f;
			myZ = myZ * 0.1f;

			transform.position = new Vector3 (transform.position.x + myX,
				transform.position.y + myZ,
				transform.position.z + myZ);
			
		}

	}
	
}
