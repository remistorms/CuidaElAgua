using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InteractableButton : MonoBehaviour {

	public bool canInteract = true;
	public void DisableButton(){

		canInteract = false;
		transform.gameObject.SetActive (false);
		//transform.DOScale (Vector3.zero, 0.2f);

	}
}
