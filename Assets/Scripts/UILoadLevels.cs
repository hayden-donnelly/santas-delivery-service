using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoadLevels : MonoBehaviour 
{
	[SerializeField] int levelIndex;

	public void LoadLevel()
	{
		SceneManager.LoadScene(levelIndex);
	}
}
