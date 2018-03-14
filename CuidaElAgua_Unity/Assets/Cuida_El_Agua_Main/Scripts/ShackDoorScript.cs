using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShackDoorScript : MonoBehaviour {

	public ShackScript shackRef;
	public GameObject navmeshObstacle;

	void Awake(){

	}
	public void Interact ()
	{
		shackRef.FadeOutShack ();
		navmeshObstacle.SetActive (false);
		shackRef.OpenDoor ();
		//base.buttonCanvas.gameObject.SetActive (false);

	}

	public void Update ()
	{
		
	}
}
