using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class FirstDialogue : MonoBehaviour {

	public int currentDialogueID = 0;
	public Button nextButton, secondButton;
	public TMP_Text dialogueText;

	[Header("Dialogo")]
	[TextArea(2,5)]
	public string[] dialogueParts;

	public void ShowNextDialogue(){
		if (currentDialogueID <= dialogueParts.Length-2) 
		{
			Debug.Log ("Showing dialogue");	
			currentDialogueID++;
			dialogueText.text = dialogueParts [currentDialogueID];

		} else {
			Debug.Log ("No more dialogue, get to the choppaaa");

			StartCoroutine (HideDialogue ());
			//ACTIVATE PLAYER MOVEMENT
			PlayerMovement.instance.ReturnPlayerControl();
			SwitchDialogues ();
			nextButton.gameObject.SetActive(false);
			secondButton.gameObject.SetActive (true);
			//Changes music
			SoundManager.instance.PlayMusic (1);
		}
	}

	IEnumerator HideDialogue(){
		//FADE DIALOGUE
		UI_Manager.instance.canvasGroups[1].DOFade(0, 1);
		yield return new WaitForSeconds(1);

		//Enable UI panels
		UI_Manager.instance.DisablePanels ();
		UI_Manager.instance.panels [2].SetActive (true);
		UI_Manager.instance.panels [3].SetActive (true);
		UI_Manager.instance.canvasGroups [2].alpha = 0;
		UI_Manager.instance.canvasGroups [2].DOFade (1, 3);

		yield return new WaitForSeconds (1);

		UI_Manager.instance.panels [0].SetActive (false);
		UI_Manager.instance.panels [1].SetActive (false);

		//ACTIVATE PLAYER MOVEMENT
		PlayerMovement.instance.ReturnPlayerControl();
	}

	public void SwitchDialogues(){
		GetComponent<SecondDialogue> ().enabled = true;
		GetComponent<SecondDialogue> ().secondDialogueEnabled = true;
		//GetComponent<SecondDialogue> ().ShowFirstText ();
		GetComponent<FirstDialogue> ().enabled = false;
		nextButton.transform.gameObject.SetActive (false);
		secondButton.transform.gameObject.SetActive (true);
		//Destroy (gameObject.GetComponent<FirstDialogue> (), 3);
	
	}

	void Start(){
		//secondButton.transform.gameObject.SetActive (false);
	}
}
