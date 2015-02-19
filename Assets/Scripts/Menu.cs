using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class Menu : MonoBehaviour
{
	void DisplayScore()
	{
		Rect IconRect = new Rect(10, 10, 32, 32);                      
		int highscore = PlayerPrefs.GetInt("High Score");

		GUIStyle style = new GUIStyle();
		style.fontSize = 25;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.black;
		
		Rect labelRect = new Rect(IconRect.xMax, IconRect.y, 60, 32);
		GUI.Label(labelRect, "High Score : "+highscore.ToString(), style);
	}

	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;
		
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);

		DisplayScore();

		// Draw a button to start the game
		if(GUI.Button(buttonRect,"Start!"))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("Game");
		}

	}
}