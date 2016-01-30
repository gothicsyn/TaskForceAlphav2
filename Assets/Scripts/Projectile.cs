// <summary>
/// Projectile.cs
/// 11-01-14
/// M A Plant
/// 
/// This is the controller for all fired player projectiles
/// </summary>
using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float ProjectileSpeed;
	public GameObject ExplosionPrefab;
	
	private Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Sets the rate Attribute which as projectile moves
		float amtToMove = ProjectileSpeed * Time.deltaTime;
		myTransform.Translate (Vector3.up * amtToMove);
		
		if (myTransform.position.y > 6.4f)
			Destroy (gameObject);
	}

	// Defines collison and action when projectile collides with enemy 
	void OnTriggerEnter(Collider otherObject){
		if (otherObject.tag == "enemy"){
			Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
			Instantiate (ExplosionPrefab, enemy.transform.position, enemy.transform.rotation);
			enemy.PowerUpSpawn();
			enemy.SetPositionAndSpeed();
			
			Destroy(gameObject);
			Player.Score += 100;

			// Resets the timer and moves to the next level
			if (Controller.gameTimer == 0){
				Player.Missed = 0;
				Application.LoadLevel(Application.loadedLevel + 1);
				Player.shieldOn = false;
				Controller.gameTimer = 60;
			}
		}
	}
}