using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class activateDoorButton : MonoBehaviour {

	public Button lockedDoorButton;
	public GameObject lastScreen;

	public void EnableLockButton(){
		lockedDoorButton.interactable = true;
	}

	public void EndDemo(){
	//Finally
		StartCoroutine(EndDemoRoutine());
	}

	IEnumerator EndDemoRoutine(){
		lockedDoorButton.transform.DOScale(Vector3.zero, 0.2f);
		UI_Manager.instance.DisablePanels ();
		UI_Manager.instance.panels[0].SetActive(true);
		UI_Manager.instance.canvasGroups [0].alpha = 0;
		UI_Manager.instance.canvasGroups [0].DOFade (1, 2f);

		yield return new WaitForSeconds(2);
		//SHOW END DEMO SCREEN
		lastScreen.SetActive(true);
		lastScreen.gameObject.GetComponent<CanvasGroup>().DOFade(1, 1);

		//yield return new WaitForSeconds(2);
		//SceneManager.LoadScene (1);
	}


}
