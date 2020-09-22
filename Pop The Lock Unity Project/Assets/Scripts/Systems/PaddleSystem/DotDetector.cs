using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will detect the collision between the dot and the paddle
//Place this script on the Paddle

public class DotDetector : MonoBehaviour 
{
	public GameData GameData;
	GameObject currentDot;
	GameObject lastEnteredDot;
	
	public GameEvent OnDotMissed;
	public GameEvent OnDotScored;
	public GameEvent OnWinEvent;
	public GameEvent OnStarScored;
	//This is when you would tap the touch screen where the game is but you could still touch UI icons so we sectioned off the screen
	public float LoseThreshold = 0.3f;
	
	void OnTriggerEnter2D(Collider2D col)
	{
		currentDot = col.gameObject;
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		lastEnteredDot = currentDot;
		currentDot = null;
	}
	
	void Update()
	{
		if(GameData.IsRunning)
		{
			if(lastEnteredDot && GetDistanceFromLastDot() > LoseThreshold)
			{
				OnDotMissed.Raise();
			}
		}
	}

	float GetDistanceFromLastDot()
	{
		return (transform.position - lastEnteredDot.transform.position).magnitude;
	}

	public void Tapped()
	{
		if(currentDot != null)
		{
			Star star = currentDot.GetComponent<Star>();
			if(star != null)
			{
				OnStarScored.Raise();
				GameData.Stars ++;		
			}

			Destroy(currentDot);
			GameData.DotsRemaining--;

			if(GameData.DotsRemaining <= 0)
			{
				GameData.DotsRemaining = 0;
				GameData.CurrentLevel++;
				OnWinEvent.Raise();
			}
			
			else
			{
				OnDotScored.Raise();				
			}
			
		}

		else
		{
			if(!GameData.isFirstTap && GameData.IsRunning)
			//Call the dot missed event when we click while not colliding
			OnDotMissed.Raise();
		}
	}
}