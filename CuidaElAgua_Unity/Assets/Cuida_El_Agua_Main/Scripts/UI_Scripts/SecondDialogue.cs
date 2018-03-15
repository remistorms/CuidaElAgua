using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class SecondDialogue : MonoBehaviour {

	public GameObject crate;
	public bool secondDialogueEnabled = false;
	public int currentDialogueID = 0;
	public Button nextButton;
	public TMP_Text dialogueText;
	public GameObject vortexSliderGO;

	[Header("Dialogo")]
	[TextArea(2,5)]
	public string[] dialogueParts;

	public void ShowNextDialogue(){
		if (currentDialogueID <= dialogueParts.Length-2 && secondDialogueEnabled) 
		{
			Debug.Log ("Showing dialogue");	
			currentDialogueID++;
			dialogueText.text = dialogueParts [currentDialogueID];

		} else {
			Debug.Log ("No more dialogue, get to the choppaaa");

			StartCoroutine (HideDialogue ());
			//ACTIVATE PLAYER MOVEMENT
			PlayerMovement.instance.ReturnPlayerControl();
			//Activate vortex slider
			vortexSliderGO.SetActive(true);
			crate.GetComponent<NewInteractable> ().enabled = true;
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

		yield return new WaitForSeconds (2);
		dialogueText.text = dialogueParts [0];
	}


	public void UpdateSliderVisibility(float newAlpha){
		vortexSliderGO.GetComponent<CanvasGroup> ().alpha = newAlpha;
	}

	public void UpdateSliderFill(float newFill){
		vortexSliderGO.GetComponent<Slider> ().value = newFill;
	}

}
