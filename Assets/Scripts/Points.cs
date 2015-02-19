using UnityEngine;

/// <summary>
/// Start or quit the game
/// </summary>
public class Points : MonoBehaviour
{
	void DisplayPointsCount()
	{
		Rect coinIconRect = new Rect(10, 10, 32, 32);                      
		
		GUIStyle style = new GUIStyle();
		style.fontSize = 25;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.black;
		
		Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
		GUI.Label(labelRect, "Points : "+Player.points.ToString(), style);
	}

	void OnGUI()
	{
		DisplayPointsCount();
	}
}