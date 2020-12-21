using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelManager : MonoBehaviour 
{
	[SerializeField] int NumberOfScenes;
	int CurrentScene;

	void Awake()
	{
		CurrentScene = SceneManager.GetActiveScene().buildIndex;
	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			ReloadCurrentLevel();
		}
	}
	public void ReloadCurrentLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
