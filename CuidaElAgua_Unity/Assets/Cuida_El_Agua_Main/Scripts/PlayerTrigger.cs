using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Makes sure its a trigger and dissables rendere on start... how cool eh?
		GetComponent<Collider> ().isTrigger = true;
		GetComponent<MeshRenderer> ().enabled = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Debug.Log ("Player has entered " + this.name + " trigger");

		}
	}
}
