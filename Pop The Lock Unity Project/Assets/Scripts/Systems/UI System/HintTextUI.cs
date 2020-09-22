using UnityEngine;

public class HintTextUI : MonoBehaviour
{
	public GameData GameData;
	//Again...we should be using the "using TMPro namespace"
	TMPro.TextMeshProUGUI hintText;
	
	void Update()
	{
		if(GameData.CurrentLevel != 1)
        {
            gameObject.SetActive(false);
        }
	}
}