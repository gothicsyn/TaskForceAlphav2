using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour {
	TrailRenderer tr;

	void Awake () {
		tr = GetComponent<TrailRenderer>();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Activate (bool activate = true) {
		if (activate) {
			// Enable any assigned effects from within this function
			tr.enabled = true;
		} 
		else {
			// Turns off all assigned effects
			tr.enabled = false;
		}
	}
}
