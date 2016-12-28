﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {
	[SerializeField]GameObject asteroid;
	[SerializeField]int numberOfAsteroidsOnAnAxis = 10;
	[SerializeField]int gridSpacing = 100;

	// Use this for initialization
	void Start () {
		PlaceAsteroids ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlaceAsteroids () {
		for (int x = 0; x < numberOfAsteroidsOnAnAxis; x++) {
			for (int y = 0; y < numberOfAsteroidsOnAnAxis; y++) {
				for (int z = 0; z < numberOfAsteroidsOnAnAxis; z++) {
					
				InsantiateAsteroids (x, y, z);
				}
			}
		}
	}

	void InsantiateAsteroids (int x, int y, int z) {
		Instantiate (asteroid, 
			new Vector3(transform.position.x + (x * gridSpacing) + AsteroidOffset(), 
				transform.position.y + (y * gridSpacing) + AsteroidOffset(), 
				transform.position.z + (z * gridSpacing) + AsteroidOffset()), 
					Quaternion.identity, transform);
	}

	float AsteroidOffset () {
		return Random.Range (-gridSpacing / 2f, gridSpacing / 2f);
	}
}
