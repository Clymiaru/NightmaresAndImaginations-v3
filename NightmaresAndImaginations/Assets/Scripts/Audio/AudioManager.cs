using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;
	public AudioMixerGroup mixerGroup;
	public Sound[] sounds;

	// BGM
	public const string MAIN_MENU_BGM = "MainMenuBGM";
	public const string TUTORIAL_LEVEL_BGM = "TutorialBGM";
	public const string LEVEL_1_BGM = "Level1BGM";
	public const string LEVEL_2_BGM = "Level2BGM";
	public const string BOSS_LEVEL_BGM = "BossLevelBGM";

	// SFX
	public const string DASH_SFX = "DashSFX";
	public const string JUMP_SFX = "JumpSFX";
	public const string GROUND_ATTACK_SFX = "GroundAttackSFX";
	public const string SWORD_SLASH_SFX = "SwordSlashSFX";
	public const string PLAYER_FAIL_SFX = "PlayerFailSFX";


	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}


    public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		//s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		//s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();

	}


	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		//s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		//s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
		s.source.Stop();
	}

}
