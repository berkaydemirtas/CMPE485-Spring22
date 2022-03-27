using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerManager : MonoBehaviour
{
    public AudioSource _source;
	public AudioClip music;

	
	void Start()
    {
        _source = GetComponent<AudioSource>();
		_source.clip = music;
		_source.Play();
	}


}
