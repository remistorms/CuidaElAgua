using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	public AudioSource gameAudio;
	public AudioClip[] musicFiles;

	void Awake(){
		instance = this;
	}

	public void PlayMusic(int id)
	{
		StartCoroutine (ChangeAudioRoutine (id));
	}

	void SlowlyModifyVolume(float newVolume){
		DOTween.To (
			()=> gameAudio.volume,
			x=> gameAudio.volume = x,
			newVolume,
			1
		);
	}

	IEnumerator ChangeAudioRoutine(int newTrack){
		SlowlyModifyVolume (0);
		yield return new WaitForSeconds (1);
		gameAudio.Stop ();
		gameAudio.clip = musicFiles [newTrack];
		gameAudio.Play ();
		SlowlyModifyVolume (1);
	}

}
