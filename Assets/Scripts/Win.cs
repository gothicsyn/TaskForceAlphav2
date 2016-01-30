using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	public int buttonWidth = 200;
	public int buttonHeight = 50;
	
	
	void OnGUI() {
	
		// Resets the Game to Level 1
		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2, 
		                          Screen.height / 2 - buttonHeight / 2, buttonWidth, buttonHeight), 
		                		  "Congratulations\nPress to Play Again")){
								  
			// Resets the games global parameters
			Player.Score = 0;
			Player.Lives = 3;
			Player.Shields = 2;
			Player.Missed = 0;
			Application.LoadLevel(1);
			Shield.shieldStrength = 3;
		}

		// Directs to the Credits screen
		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2, 
		                          Screen.height / 2 - buttonHeight / 10 + 100, buttonWidth, buttonHeight), 
		                		  "Credits")){
			Application.LoadLevel("Credits");
		}
	}
}
