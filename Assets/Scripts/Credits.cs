using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public int buttonWidth = 200;
	public int buttonHeight = 50;

	// Use this for initialization
	void OnGUI() {
		GUI.BeginGroup (new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 300));

		// Text Container
		GUI.Box (new Rect(0, 0, 200, 300), "Task Force Alpha");

		// Internal Texts
		GUI.Label(new Rect(10, 40, 200, 50), "Designer         Mark Plant");
		GUI.Label(new Rect(10, 70, 200, 50), "Software         Mark Plant");
		GUI.Label(new Rect(10, 100, 200, 50), "Level Design    Mark Plant");
		GUI.Label(new Rect(10, 130, 200, 50), "Artwork         Ashley Baker");
		GUI.Label(new Rect(10, 160, 200, 50), "Testing         Ashley Jackson");

		// Button for returning to the Main Menu
	if (GUI.Button (new Rect (15, 180, buttonWidth, buttonHeight), "Main Menu")){
			Application.LoadLevel("MainMenu");
		}

		// Button to load the company site
	if (GUI.Button (new Rect (15, 200, buttonWidth, buttonHeight), "Website")){
			Application.OpenURL("http://devilsincstudios.com");
		}
		GUI.EndGroup();
	}
}