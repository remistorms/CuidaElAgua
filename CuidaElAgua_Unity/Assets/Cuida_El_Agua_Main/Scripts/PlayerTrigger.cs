using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {

	public ShackScript shackRef;

	// Use this for initialization
	void Start () {
		//Makes sure its a trigger and dissables rendere on start... how cool eh?
		GetComponent<Collider> ().isTrigger = true;
		GetComponent<MeshRenderer> ().enabled = false;
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			
			shackRef.FadeInShack ();
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && !shackRef.isShakInvisible) {

			shackRef.FadeOutShack ();
		}
	}
}
