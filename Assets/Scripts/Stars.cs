using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () {
	
		// Sets the rate at which the planes move down screen
		float amtToMove = speed * Time.deltaTime;
		transform.Translate(Vector3.down * amtToMove, Space.World);

		// Resets a planes position once it leaves the screen
		if (transform.position.y < -10.75){
			transform.position = new Vector3(transform.position.x, 14f, transform.position.z);
		}
	}
}
