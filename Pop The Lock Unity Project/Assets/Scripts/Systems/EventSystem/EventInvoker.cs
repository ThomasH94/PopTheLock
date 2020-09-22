using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInvoker : MonoBehaviour
{
	public GameEvent EventToRaise;
	
	public void Raise()
	{
		EventToRaise.Raise();
	}
}