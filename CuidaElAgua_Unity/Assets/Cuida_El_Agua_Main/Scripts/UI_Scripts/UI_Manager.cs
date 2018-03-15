using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.PostProcessing;

public class UI_Manager : MonoBehaviour {

	public static UI_Manager instance;
	public PostProcessingProfile postEffects;
	public GameObject[] panels;
	public List<CanvasGroup> canvasGroups;
	public TextMeshProUGUI introText;
	public GameObject teleportParticles;
	GameObject playerRef;
	public GameObject playerGlow;
	public Light playerPointLight;

	// Use this for initialization
	void Start () {
		instance = this;
		InitializePanels ();
		introText.color = new Color (introText.color.r, 
									introText.color.g,
									introText.color.b, 
									0.0f
		);
		//Activates fade panel
		panels [0].SetActive (true);
		StartCoroutine (StartRoutine ());

		//Gets Player ref
		playerRef = GameObject.FindGameObjectWithTag("Player");
		playerRef.transform.localScale = new Vector3 (0, 2, 0);
		//playerRef.SetActive (false);
		playerPointLight.intensity = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InitializePanels(){

		foreach (var item in panels) {
			
			canvasGroups.Add(item.GetComponent<CanvasGroup>());
			RectTransform panelRect = item.GetComponent<RectTransform> ();
			panelRect.offsetMin = panelRect.offsetMax = Vector2.zero;
		}

		DisablePanels ();
	}

	public void DisablePanels(){
		foreach (var item in panels) {
			item.SetActive (false);
		}
	}

	float fadeTime = 2;

	IEnumerator StartRoutine(){
		//FADE IN TEXT
		yield return new WaitForSeconds (fadeTime);
		introText.text = "REM STORMS";
		introText.DOFade (1, fadeTime);
		yield return new WaitForSeconds (fadeTime);
	
		//FADE OUT and CHANGE TEXT
		introText.DOFade (0f, fadeTime);
		yield return new WaitForSeconds (fadeTime);
		introText.text = "ESTE DEMO ESTA EN FASE DE DESARROLLO, GRACIAS POR JUGAR...";
		yield return new WaitForSeconds (fadeTime);
		introText.DOFade (1, fadeTime);
		yield return new WaitForSeconds (5);

		/*
		//FADE OUT and CHANGE TEXT
		yield return new WaitForSeconds (fadeTime);
		introText.DOFade (0f, fadeTime);
		yield return new WaitForSeconds (fadeTime);
		introText.text = " ''MILES DE PERSONAS HAN SOBREVIVIDO SIN AMOR.... NADIE HA SOBREVIVIDO SIN AGUA...'' ";
		yield return new WaitForSeconds (fadeTime);
		introText.DOFade (1, fadeTime);*/

		//FADE OUT and CHANGE TEXT
		introText.DOFade (0f, fadeTime);
		yield return new WaitForSeconds (fadeTime);
		introText.text = " ...2018, POCO ANTES DE LA SEQUIA GLOBAL... ";
		yield return new WaitForSeconds (4);
		introText.DOFade (1, fadeTime);

		//FADE OUT
		yield return new WaitForSeconds (6);
		introText.DOFade (0, fadeTime);
		yield return new WaitForSeconds (3);


		canvasGroups [0].DOFade (0, 3*fadeTime);
		yield return new WaitForSeconds (3*fadeTime);
		canvasGroups [0].transform.gameObject.SetActive (false);

		//Spawn player
		playerPointLight.intensity = 10;
		Vector3 teleportScale = teleportParticles.transform.localScale;
		teleportParticles.transform.localScale = Vector3.zero;
		teleportParticles.SetActive (true);
		teleportParticles.transform.DOScale (teleportScale, 2);
		yield return new WaitForSeconds (1.5f);
		playerRef.SetActive (true);

		playerRef.transform.position = new Vector3 ( teleportParticles.transform.position.x,
														playerRef.transform.position.y,
														teleportParticles.transform.position.z);
		playerRef.transform.DOScale (Vector3.one, 1f);
		yield return new WaitForSeconds (2.5f);
		teleportParticles.transform.DOScale (new Vector3 (0, 1, 0), 2.5f);
		yield return new WaitForSeconds (2.5f);

		DOTween.To (
			()=> playerPointLight.intensity,
			x=> playerPointLight.intensity = x,
			0,
			2
		);

		playerGlow.transform.DOScale (Vector3.zero, 2);
		teleportParticles.SetActive (false);

		StartCoroutine (ShowDialogue ());

	}

	public void ShowDialogueRoutine(){
		StartCoroutine (ShowDialogue ());
	}

	IEnumerator ShowDialogue(){
	
		yield return new WaitForSeconds (1);
		DisablePanels ();
		playerRef.GetComponent<PlayerMovement> ().playerHasControl = false;
		panels [1].SetActive (true);
		canvasGroups [1].alpha = 0;
		canvasGroups [1].DOFade (1, 2);
	}
}
