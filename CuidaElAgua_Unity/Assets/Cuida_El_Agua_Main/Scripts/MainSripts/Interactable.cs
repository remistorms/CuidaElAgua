using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour {

	public RectTransform buttonCanvas;
	Vector2 originalCanvasSize;
	public bool canInteract = true;

	public float interactionDistance = 0.5f;

	public virtual void Initialize(){
		this.tag = "interactable";
		if (GetComponent<SphereCollider>() == null) {
			this.transform.gameObject.AddComponent<SphereCollider> ();
		}
		GetComponent<SphereCollider> ().isTrigger = true;

		originalCanvasSize = buttonCanvas.localScale;
		buttonCanvas.localScale = Vector2.zero;


	}

	public virtual void Interact(){
		Debug.Log ("Interact from the parent class Interactable");

	}

	public virtual void Update(){
		if ((Vector3.Distance(PlayerMovement.instance.gameObject.transform.position, this.gameObject.transform.position) <= interactionDistance) && (canInteract == true)) {
			ShowInteractionIcon ();
		}
	}

	public void ShowInteractionIcon(){
		buttonCanvas.DOScale (originalCanvasSize, 0.5f);
	}

	public void HideInteractionIcon(){
		buttonCanvas.DOScale (Vector2.zero, 0.5f);
	}

}
