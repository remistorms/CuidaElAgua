using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShackScript : MonoBehaviour {

	public Camera shackCamera;
	public GameObject doorPivot, shackTopMesh;
	public Material normalMaterial, fadeMaterial;
	public float fadeDuration = 1f;
	public bool isShakInvisible = false;

	void Update(){
		if (Input.GetKeyDown(KeyCode.F)) {
			if (!isShakInvisible) {
				FadeOutShack ();
			} else {
				FadeInShack ();
			}

		}

	}

	public void OpenDoor(){
	//Open door
		doorPivot.transform.DORotate(
		
			new Vector3(0,-120,0),
			0.5f,
			RotateMode.LocalAxisAdd
		);
	}

	public void CloseDoor(){
		//Open door
		doorPivot.transform.DORotate(

			new Vector3(0,0,0),
			0.5f,
			RotateMode.LocalAxisAdd
		);
	}

	public void FadeOutShack(){
		//Changes material to fade material
		shackTopMesh.GetComponent<MeshRenderer> ().material = fadeMaterial;
		//Fades material to transparent
		fadeMaterial.DOFade (0.1f, fadeDuration);
		isShakInvisible = true;
	}

	public void FadeInShack(){
		StartCoroutine (FadeInShackRoutine ());
	}

	IEnumerator FadeInShackRoutine(){
		
		fadeMaterial.DOFade (1, fadeDuration);
		yield return new WaitForSeconds (fadeDuration);
		shackTopMesh.GetComponent<MeshRenderer> ().material = normalMaterial;
		isShakInvisible = false;
	}


}
