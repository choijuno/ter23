using UnityEngine;
using System.Collections;

public class SoundManager : Singleton<SoundManager>
{
	AudioSource _audioSource;
	
	public AudioClip _BtnSound;
	public AudioClip _BGMSound;

	void Start()
	{
		_audioSource = GetComponent<AudioSource>();
	}
	
	public void BGM_SoundON()
	{
		_audioSource.clip = _BGMSound;
		_audioSource.Play();
	}
	public void BGM_SoundOFF()
	{
		_audioSource.Stop();
	}
	public void _BtnSoundON()
	{
		
	}
}
