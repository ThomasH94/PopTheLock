using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
	public GameEvent[] Events;
	public UnityEvent Response;
	
	//Add me to the list of listeners
	void OnEnable()
	{
		foreach(GameEvent gameEvent in Events)
		{
			gameEvent.Register(this);
		}
	}
	
	void OnDisable()
	{
		foreach(GameEvent gameEvent in Events)
		{
			gameEvent.DeRegister(this);
		}
	}
	
	public void OnEventRaised()
	{
		Response.Invoke();
	}
	
}