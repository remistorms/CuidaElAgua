using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColliderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Disables all trigger renderers
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).GetComponent<MeshRenderer> ().enabled = false;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
