using UnityEngine;

public class GameOver : MonoBehaviour
{
	void OnGUI()
	{
		const int buttonWidth = 120;
		const int buttonHeight = 70;
		
		if (
			GUI.Button(
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(1 * Screen.height / 3 + 30) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Retry!"
			)
			)
		{
			Player.points = 0;
			Application.LoadLevel("Game");
		}
		
		if (
			GUI.Button(
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3 - 30) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Menu"
			)
			)
		{		
			Player.points = 0;
			Application.LoadLevel("Menu");
		}
	}
}