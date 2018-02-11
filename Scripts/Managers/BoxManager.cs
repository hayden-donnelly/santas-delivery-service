using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour 
{
	public int NumberOfBoxes = 0;
	[SerializeField] Text currentScoreDisplay;

	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Box")
		{
			NumberOfBoxes += 1;
		}
	}
	void OnTriggerExit(Collider c)
	{
		if(c.tag == "Box")
		{
			NumberOfBoxes -= 1;
		}
	}
	void Update()
	{
		DisplayCurrentScore();
	}
	void DisplayCurrentScore()
	{	if(currentScoreDisplay != null)
		{
			currentScoreDisplay.text = "SCORE " + NumberOfBoxes.ToString();
		}	
	}
}

