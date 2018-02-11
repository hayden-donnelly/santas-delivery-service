using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour 
{
	[SerializeField] GameObject failMessage;
	[SerializeField] GameObject finishLineTrigger;
	[SerializeField] Text timeDisplay;
	[SerializeField] GameObject currentScoreDisplay;

	[SerializeField] float timeLimit;
	float time = 0.0f;
	
	void Start()
	{
		time = timeLimit;
	}
	void Update()
	{
		time -= Time.deltaTime;
		DisplayTime();
		
		if(time <= 0)
		{
			Destroy(finishLineTrigger);
			failMessage.SetActive(true);
			Destroy(currentScoreDisplay);
			Destroy(this);
		}
	}
	void DisplayTime()
	{
		timeDisplay.text = "TIME " + Mathf.RoundToInt(time).ToString();
	}
}
