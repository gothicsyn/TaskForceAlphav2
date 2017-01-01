using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour {
	[SerializeField]GameObject explosion;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void IveBeenHit(Vector3 pos) {
		GameObject go = Instantiate (explosion, pos, Quaternion.identity, transform) as GameObject;
		Destroy (go, 6f);
	}
}
