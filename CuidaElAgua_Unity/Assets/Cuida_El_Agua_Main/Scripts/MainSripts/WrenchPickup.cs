using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WrenchPickup : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {

			this.transform.DOMove (other.transform.position, 0.5f);
			this.transform.DOScale (Vector3.zero, 0.5f);
			//Give player wrench tool

			Destroy (this.gameObject, 1f);

		}
	}
}
