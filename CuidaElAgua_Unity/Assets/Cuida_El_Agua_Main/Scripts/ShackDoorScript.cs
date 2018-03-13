using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShackDoorScript : Interactable {

	public ShackScript shackRef;
	public GameObject navmeshObstacle;

	void Awake(){
		base.Initialize ();
	}
	public override void Interact ()
	{
		base.Interact ();
		shackRef.FadeOutShack ();
		navmeshObstacle.SetActive (false);
		shackRef.OpenDoor ();
		base.buttonCanvas.gameObject.SetActive (false);

	}

	public override void Update ()
	{
		base.Update ();


		buttonCanvas.LookAt (2 * transform.position - Camera.main.transform.position);
		//Check if player has required item in inventory
		if ((Vector3.Distance(PlayerMovement.instance.gameObject.transform.position, this.gameObject.transform.position) <= interactionDistance) && (canInteract == true)) {
			ShowInteractionIcon ();
		}
	}
}
