using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerMovement : MonoBehaviour {
	[SerializeField]float movementSpeed = 100;
	[SerializeField]float turnSpeed = 50;
	[SerializeField]Thruster[] thruster;

	Transform myT;

	// Use this for things started as the game loads
	void Awake () {
		myT = transform;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Turn ();
		Thrust ();
	}

	void Turn () {
	// input * Turn * Time
		float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
		float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
		float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

		myT.Rotate (-pitch, yaw, roll);
	}

	void Thrust () {
		if (Input.GetAxis ("Vertical") > 0) {
			myT.position += myT.forward * movementSpeed * Time.deltaTime * Input.GetAxis ("Vertical");
				foreach (Thruster t in thruster)
				t.Intensity (Input.GetAxis ("Vertical"));
		}
//		if(Input.GetKeyDown(KeyCode.W))
//			foreach (Thruster t in thruster)
//				t.Activate ();
//			else if (Input.GetKeyUp(KeyCode.W))
//				foreach (Thruster t in thruster)
//					t.Activate (false);
	}
}
