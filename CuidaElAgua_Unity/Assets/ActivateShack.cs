using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShack : MonoBehaviour {

	public void ActivateShackInteractiveDoor(){
		gameObject.GetComponent<NewInteractable> ().enabled = true;
	}
}
