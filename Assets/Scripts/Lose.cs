using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {

	public Texture BgTexture; // Allows selection of specific texture

	// Draws the required texture to the screen and resets global variables
	void OnGUI() {
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), BgTexture);
			if (Input.anyKeyDown){
				Player.Score = 0;
				Player.Lives = 3;
				Player.Shields = 2;
				Player.Missed = 0;
				Controller.gameTimer = 60;
					Application.LoadLevel(1);
		}
	}
}