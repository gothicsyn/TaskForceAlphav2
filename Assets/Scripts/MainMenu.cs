using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture BgTexture;
	private string Instructions = "Controls :\nPress Left And Right To Move.\nPress V to Activate Shields\nPress Spacebar to Fire\nPress F2 to return to the Main Menu\n\nPress Any Key To Play.";

	void OnGUI() {

		// Draws the menu texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), BgTexture);

		// Writes the information in the top Right
		GUI.Label (new Rect (10, 10, 200, 200), Instructions);
		if (Input.anyKeyDown)
				Application.LoadLevel(1);
	}
}