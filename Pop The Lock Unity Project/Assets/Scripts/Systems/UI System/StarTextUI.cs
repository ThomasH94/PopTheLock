using UnityEngine;

public class StarTextUI : MonoBehaviour
{
	public GameData GameData;
	//Again...we should be using the "using TMPro namespace"
	TMPro.TextMeshProUGUI starText;
	
	void Start()
	{
		starText = GetComponent<TMPro.TextMeshProUGUI>();
		DisplayStars();
	}
	
	void Update()
	{
		DisplayStars();
	}
	
	void DisplayStars()
	{
		starText.text = "Stars: " + GameData.Stars.ToString();
	}
}