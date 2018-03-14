using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemPickup : MonoBehaviour {

	public void PickupItem(){

		this.transform.SetParent (PlayerMovement.instance.transform);
		this.transform.DOMove (PlayerInventory.instance.transform.position, 0.5f);
		this.transform.DOScale (Vector3.zero, 0.5f);
		//Give player wrench tool
		PlayerInventory.instance.AddItem(this.GetComponent<Item>().itemID);
		//ItemsMenu.instance.AddButton (this.GetComponent<Item> ().itemButton);
		//ADDS this pickup item icon to the quee
		ItemsMenu.instance.AddItemToInventory(this.GetComponent<Item>().itemSprite);
		//GetComponent<NewInteractable> ().interactableButton.transform.gameObject.SetActive (false);
		Destroy (this.gameObject, 1f);
	}
}
