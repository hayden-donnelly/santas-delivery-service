using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeAudio : MonoBehaviour 
{
	[SerializeField] AudioSource audioSource;
	bool FirstTime = true;

	private void Start()
	{
		if(GameObject.FindGameObjectsWithTag("AudioListener").Length == 1) 
		{
			audioSource.Play();
			FirstTime = false;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
