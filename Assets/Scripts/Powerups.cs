using UnityEngine;
using System.Collections;

public class Powerups : MonoBehaviour {

	public float ObjectSpeed;

	private Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		float amtToMove = ObjectSpeed * Time.deltaTime;
		myTransform.Translate (Vector3.down * amtToMove, Space.World);
		
		if (myTransform.position.y <= -5f)
			Destroy (gameObject);
	}

	void OnTriggerEnter (Collider otherObject){
	if (otherObject.tag == "Player"){
		Player.Lives += 1;
		Destroy (gameObject);
		}
	}
}
