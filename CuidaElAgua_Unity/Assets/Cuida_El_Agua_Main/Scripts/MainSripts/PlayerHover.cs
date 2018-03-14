using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHover : MonoBehaviour {

	public float hoverHeight = 0.5f;
	public GameObject playerModel;

	// Use this for initialization
	void Start () {
	
		iTween.MoveAdd (playerModel, iTween.Hash(
			"y", hoverHeight,
			"time", 2f,
			"looptype", iTween.LoopType.pingPong,
			"easetype", iTween.EaseType.easeInOutSine
		));
	}

}
