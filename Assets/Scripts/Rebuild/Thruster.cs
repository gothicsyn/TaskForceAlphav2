using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour {
//	TrailRenderer tr;
	Light thrusterLight;

	void Awake () {
//		tr = GetComponent<TrailRenderer>();
		thrusterLight = GetComponent<Light> ();
	}

	// Use this for initialization
	void Start () {
//		tr.enabled = false;
//		thrusterLight.enabled = false;
		thrusterLight.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

//	public void Activate (bool activate = true) {
//		if (activate) {
			// Enable any assigned effects from within this function
//			tr.enabled = true;
//			thrusterLight.enabled = true;
//		} 
//		else {
			// Turns off all assigned effects
//			tr.enabled = false;
//			thrusterLight.enabled = false;
//		}
//	}

	public void Intensity (float inten) {
		thrusterLight.intensity = inten * 2f;
	}
}
