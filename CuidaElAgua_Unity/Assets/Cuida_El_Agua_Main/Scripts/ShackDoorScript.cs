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
	}
}
