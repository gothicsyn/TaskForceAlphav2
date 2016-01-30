// <summary>
/// Projectile.cs
/// 09-03-14
/// M A Plant
/// 
/// This is a global controller for the game
/// </summary>
using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public GUISkin GUISkin;
	public static int gameTimer = 60;

		// Set global parameters here
		void Awake(){
	}
		// Use this for initialization
		void Start (){
		InvokeRepeating ("CountDown", 1f, 1f);
	}
	
		// Update is called once per frame
		void Update (){	

		// Sets the secondary lose condition
		if (Player.Missed >= 15){
			Application.LoadLevel ("Loss");
			gameTimer = 60;
		}

		GUIChecker ();{
		}

		GlobalControl();{
		}
	}

	// Controls the GUI displays of the game overall

	void OnGUI(){
		BuildUI();
	}

	void BuildUI(){
		GUI.skin = GUISkin;
		GUI.color = Color.red;
		GUI.Label (new Rect(10, 10, 300, 40), "Score : " + Player.Score.ToString());
		GUI.Label (new Rect(10, 40, 200, 40), "Lives : " + Player.Lives.ToString());
		GUI.Label (new Rect(10, 70, 240, 40), "Missed : " + Player.Missed.ToString());
		GUI.Label (new Rect(10, 100, 240, 40), "Shields : " + Player.Shields.ToString());
		GUI.Label (new Rect(300, 10, 240, 40), "Timer : " + Controller.gameTimer.ToString());
	}

	// Checks for the status of various variables ingame gobally
	public void GUIChecker (){

		// Checks for the status of various variables ingame gobally
		if (Player.Shields == 6){
			Player.Score += 200;
			Player.Shields = 5;
		}

		if (Player.Lives == 6){
			Player.Score += 200;
			Player.Lives = 5;
		}
	}

	// Cancels out the games counter once it hits zero
	public void CountDown (){
		if (--gameTimer == 0) {
			CancelInvoke("CountDown");
		}
	}

	public void GlobalControl(){
		if (Input.GetKeyDown("f2"))
			Application.LoadLevel ("MainMenu");
	}
}