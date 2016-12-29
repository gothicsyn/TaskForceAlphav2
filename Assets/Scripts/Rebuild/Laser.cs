﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour {
	[SerializeField]float laserOffTime = .5f;
	[SerializeField]float maxDistance = 100;
	LineRenderer lr;
	bool canFire;

	void Awake () {
		lr = GetComponent<LineRenderer>();
	}


	// Use this for initialization
	void Start () {
		lr.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
//		FireLaser (transform.forward * maxDistance);
	}

	public void FireLaser (Vector3 targetPosition) {
		if (canFire) {
			lr.SetPosition (0, transform.position);
			lr.SetPosition (1, targetPosition);
			lr.enabled = true;
			canFire = false;
		}

		Invoke ("TurnOffLaser", laserOffTime);
	}

	void TurnOffLaser () {
		lr.enabled = false;
		canFire = true;
	}
}
