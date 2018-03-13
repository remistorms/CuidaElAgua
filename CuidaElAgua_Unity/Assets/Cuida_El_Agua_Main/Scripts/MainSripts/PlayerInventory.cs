using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

	public static PlayerInventory instance;
	public List<Item> obtainedItems;
	public Item[] allItems;

	void Awake(){
		instance = this;
	}

	public void AddItem(int itemID){

		//Add item to list
		obtainedItems.Add(allItems[itemID]);
		//Add button to menu.... later on
	}
}

