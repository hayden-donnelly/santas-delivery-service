using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLineManager : MonoBehaviour 
{
	[SerializeField] GameObject victoryMessage;
	[SerializeField] Text scoreDisplay;
	[SerializeField] BoxManager boxManager;
	[SerializeField] TimeManager timeManager;
	[SerializeField] GameObject currentScoreDisplay;

	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player")
		{
			DisplayScore();
			Destroy(timeManager);
		}
	}
	void DisplayScore()
	{
		victoryMessage.SetActive(true);
		scoreDisplay.text = "SCORE " + boxManager.NumberOfBoxes.ToString();
		Destroy(currentScoreDisplay);
	}
}
