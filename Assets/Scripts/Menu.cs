using UnityEngine;

public class Menu : MonoBehaviour
{

	void DisplayScore()
	{
		Rect IconRect = new Rect(Screen.width/2-130, Screen.height/2-30, 0, 0);                      
		int highscore = PlayerPrefs.GetInt("High Score");

		GUIStyle style = new GUIStyle();
		style.fontSize = 35;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.black;
		
		Rect labelRect = new Rect(IconRect.xMax, IconRect.y, 60, 32);
		GUI.Label(labelRect, "High Score : "+highscore.ToString(), style);
	}

	void OnGUI()
	{
		const int buttonWidth = 120;
		const int buttonHeight = 70;

		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3 + 30) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);

		DisplayScore();

		if(GUI.Button(buttonRect,"Start!"))
		{
			Application.LoadLevel("Game");
		}

	}
}