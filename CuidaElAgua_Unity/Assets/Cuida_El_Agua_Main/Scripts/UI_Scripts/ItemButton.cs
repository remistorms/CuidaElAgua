using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

	public int myIndex;

	void Awake(){
		myIndex = transform.GetSiblingIndex ();

	}
}
