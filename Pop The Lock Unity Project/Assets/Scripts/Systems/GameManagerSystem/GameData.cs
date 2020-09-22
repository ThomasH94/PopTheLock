using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
	public int CurrentLevel;
	public int DotsRemaining;
	public int Stars;
	public bool IsRunning = false;
	public int MinSpawnAngle = 40;
	public int MaxSpawnAngle = 100;
	public int CurrentMotorSpeed = 100;
	public int MaxMotorSpeed = 300;
	public int MinMotorSpeed = 100;
	public bool isFirstTap = true;
	public bool canTap = true;
	public GameEvent GameScreenTapped;

	public void Tapped()
	{
		if(IsRunning == false && canTap)
		{
			IsRunning = true;
		}
		GameScreenTapped.Raise();
		isFirstTap = false;
	}

	
	public void ResetLevel()
	{
		IsRunning = false;
		canTap = true;
		DotsRemaining = CurrentLevel;
	}

	public void ResetData()
	{
		CurrentLevel = 1;
		DotsRemaining = CurrentLevel;
		CurrentMotorSpeed = MinMotorSpeed;
		Stars = 0;
	}
	public void IncreaseMotorSpeed(int value)
	{
		if(value > 0)
		{
			CurrentMotorSpeed = Mathf.Min(CurrentMotorSpeed + value, MaxMotorSpeed);
		}
	}

	public void ReduceMotorSpeed(int value)
	{
		if(value > 0)
		{
			CurrentMotorSpeed = Mathf.Max(CurrentMotorSpeed - value, MinMotorSpeed);
		}
	}
	public void StopGame()
	{
		IsRunning = false;
		isFirstTap = true;
		canTap = false;
	}
}