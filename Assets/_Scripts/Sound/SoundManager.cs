using UnityEngine;
using System.Collections;

public class SoundManager : Singleton<SoundManager>
{
	AudioSource _audioSource;
	
	public AudioClip _BtnSound;
	public AudioClip _BGMSound;
	public float _BtnSoundVolume = 1.0f;

	void Start()
	{
		_audioSource = GetComponent<AudioSource>();


        BGM_SoundON();

    }
	
	//BGM 사운드 ON
	public void BGM_SoundON()
	{
		_audioSource.clip = _BGMSound;
		_audioSource.Play();
		_audioSource.loop = true;
	}
	//BGM 사운드 OFF
	public void BGM_SoundOFF()
	{
		_audioSource.Stop();
		_audioSource.loop = false;
	}

	//BUTTON 사운드 ON
	public void BtnSoundON()
	{
		 _audioSource.PlayOneShot(_BtnSound, _BtnSoundVolume);
	}
}
