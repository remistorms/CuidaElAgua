using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPointer : MonoBehaviour {

	public float timeToTween = 1f;
	public static DestinationPointer instance;
	public Transform playerRef;

	public SpriteRenderer pointerSprite;

	void Awake(){
		instance = this;
		playerRef = GameObject.FindGameObjectWithTag ("Player").transform;
		pointerSprite = GetComponent<SpriteRenderer> ();
		AnimateSprite ();
		pointerSprite.enabled = false;

	}

	public void SetPointer(Vector3 position){
		
		pointerSprite.enabled = true;
		transform.position = position;

	}

	public void HidePointer(){
		
		pointerSprite.enabled = false;
	}

	void AnimateSprite(){
		iTween.ValueTo (gameObject, iTween.Hash (
			"from", 1f,
			"to", 0f,
			"time", timeToTween,
			"looptype", iTween.LoopType.loop,
			"easetype", iTween.EaseType.linear,
			"onupdate", "UpdateAlpha",
			"onupdatetarge", gameObject,
			"name", "tweenAlpha"
		));

		iTween.ScaleTo (gameObject, iTween.Hash (
			"scale", new Vector3(2f, 2f, 2f),
			"time", timeToTween,
			"looptype", iTween.LoopType.loop,
			"easetype", iTween.EaseType.linear,
			"name", "tweenScale"
		));
	}
		
	public void UpdateAlpha(float value){

		pointerSprite.color = new Color(pointerSprite.color.r,
										pointerSprite.color.g,
										pointerSprite.color.b,
										value);
	}


	void Update(){
		if (Vector3.Distance(playerRef.position, transform.position) <= 2.5f) {
			HidePointer ();
		}
	}

}
