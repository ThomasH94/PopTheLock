using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameData GameData;
	

	
	void Start()
	{
		GameData.ResetLevel();
	}

	
	void Update()
	{

	}

	public void LoadLevel()
	{
		GameData.ResetLevel();
		GameData.isFirstTap = true;
	}

	/* 
	IEnumerator WaitToTap()
	{
		yield return new WaitForSeconds(2.0f);
		GameData.canTap = true;
	}
	*/
	
}