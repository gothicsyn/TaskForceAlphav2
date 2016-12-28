using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	[SerializeField]float minScale = 100;
	[SerializeField]float maxScale = 125;
	[SerializeField]float rotationOffset = 100;

	Transform myT;
	Vector3 randomRotation;

	// Use this for things started as the game loads
	void Awake () {
		myT = transform;
	}


	// Use this for initialization
	void Start () {
	// Instantiate Asteroid with random scale
		Vector3 scale = new Vector3 (100, 100, 100);
		scale.x = Random.Range(minScale, maxScale);
		scale.y = Random.Range(minScale, maxScale);
		scale.z = Random.Range(minScale, maxScale);

		myT.localScale = scale;

	// Instantiate Asteroid with random scale
		randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
		randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
		randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
	}
	
	// Update is called once per frame
	void Update () {
		myT.Rotate (randomRotation * Time.deltaTime);
	}
}
