using UnityEngine;

public class LevelTextUI : MonoBehaviour
{
	public GameData GameData;
	//Again...we should be using the "using TMPro namespace"
	TMPro.TextMeshProUGUI levelText;
	
	void Start()
	{
		levelText = GetComponent<TMPro.TextMeshProUGUI>();
		DisplayLevel();
	}
	
	void Update()
	{
		DisplayLevel();
	}
	
	void DisplayLevel()
	{
		levelText.text = "Level: " + GameData.CurrentLevel.ToString();
	}
}