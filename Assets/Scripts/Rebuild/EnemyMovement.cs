using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	[SerializeField]Transform target;
	[SerializeField]float movementSpeed = 1f;
	[SerializeField]float rotationalDamp = .5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Turn ();
		Move();
	}

	void Turn () {
		Vector3 pos = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation (pos);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, rotationalDamp * Time.deltaTime);
	}

	void Move () {
		transform.position += transform.forward * movementSpeed * Time.deltaTime;
	}
}
