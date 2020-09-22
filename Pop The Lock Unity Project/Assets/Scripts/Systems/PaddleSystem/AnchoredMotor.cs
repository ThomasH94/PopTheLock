using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will be used to spin our paddle around the anchorpoint
//Attach this script to the paddle
//Set the LockBase Object in the scene with the anchor tag. (It's what we will rotate around)

public enum Direction
{
	Clockwise = 1,
	CounterClockwise = -1
};

public class AnchoredMotor : MonoBehaviour
{
	public GameData GameData;
	public GameEvent OnPaddleReset;
	public int Speed = 5;

	public Direction Direction = Direction.Clockwise;
	Vector3 initialPosition;
	
	Transform anchor;
	bool canMove = false;
	
	void Start()
	{
		anchor = GameObject.FindGameObjectWithTag("Anchor").transform;
		initialPosition = GetComponent<Transform>().localPosition;
	}
	
	void Update()
	{
		if(GameData.IsRunning && canMove)
		{
			//Transform around makes this object rotate around another object
			//Rotate right if direction is clockwise, left if it's counterclockwise
			transform.RotateAround(anchor.position, Vector3.forward, GameData.CurrentMotorSpeed * Time.deltaTime * -(int)Direction);
		}
	}
	
	public void Tapped()
	{
		if(!GameData.isFirstTap && GameData.IsRunning)
		{
			ChangeDirection();
		}
		else
		{
			canMove = true;
		}
	}
	
	void ChangeDirection()
	{
		switch(Direction)
		{
			case Direction.Clockwise:
			Direction = Direction.CounterClockwise;
			break;
			
			case Direction.CounterClockwise:
			Direction = Direction.Clockwise;
			break;
		}
	}
	
	public void ResetPosition()
	{
		transform.localPosition = new Vector3(0, initialPosition.y, 0);
		transform.localRotation = Quaternion.identity;

		OnPaddleReset.Raise();
	}

	public void StopMoving()
	{
		canMove = false;
	}


}