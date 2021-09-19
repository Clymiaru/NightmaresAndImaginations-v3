using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
	private AudioManager audioManagerRef;

	void Start()
    {
        if (audioManagerRef == null)
        {
			audioManagerRef = GameObject.FindObjectOfType<AudioManager>();
			audioManagerRef = audioManagerRef.GetComponent<AudioManager>();
		}

		if (SceneManager.GetActiveScene().buildIndex == 0) // Setup Scene
		{
			audioManagerRef.Stop(AudioManager.TUTORIAL_LEVEL_BGM);
			audioManagerRef.Play(AudioManager.MAIN_MENU_BGM);
		}

		else if (SceneManager.GetActiveScene().buildIndex == 1) // Tutorial
		{
			audioManagerRef.Stop(AudioManager.MAIN_MENU_BGM);
			audioManagerRef.Play(AudioManager.TUTORIAL_LEVEL_BGM);
		}

		else if (SceneManager.GetActiveScene().buildIndex == 2) // Level 1
		{
			audioManagerRef.Stop(AudioManager.MAIN_MENU_BGM);
			audioManagerRef.Play(AudioManager.LEVEL_1_BGM);
		}

		else if (SceneManager.GetActiveScene().buildIndex == 3) // Level 2
		{
			audioManagerRef.Stop(AudioManager.LEVEL_1_BGM);
			audioManagerRef.Play(AudioManager.LEVEL_2_BGM);
		}

		else if (SceneManager.GetActiveScene().buildIndex == 4) // Level 3
		{
			audioManagerRef.Stop(AudioManager.LEVEL_1_BGM);
			audioManagerRef.Play(AudioManager.LEVEL_2_BGM);
		}

		else if (SceneManager.GetActiveScene().buildIndex == 5) // Boss Level
		{
			audioManagerRef.Stop(AudioManager.LEVEL_2_BGM);
			audioManagerRef.Play(AudioManager.BOSS_LEVEL_BGM);
		}
	}
}
