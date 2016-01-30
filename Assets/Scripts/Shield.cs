// <summary>
/// Projectile.cs
/// 14-01-14
/// M A Plant
/// 
/// This is the controller for the shield
/// </summary>
using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public static int shieldStrength = 3;
	public GameObject ExplosionPrefab;

	// Defines the action when enemy collides with the shield
	void OnTriggerEnter (Collider otherObject) {
		if (otherObject.tag == "enemy"){
			shieldStrength -= 1; 
			Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
			Instantiate (ExplosionPrefab, enemy.transform.position, enemy.transform.rotation);
			enemy.SetPositionAndSpeed();
		}
	}

	void Update (){
		// When player has shield
		if (shieldStrength <= 0){
			Destroy(gameObject);
			shieldStrength = 3;
			Player.Shields -=1;
			Player.shieldOn = false;
		}

		// When player doesnt have shield
		if (Player.Shields <= 0){
			Player.Shields = 0;
			Destroy(gameObject);
			shieldStrength = 3;
			Player.shieldOn = false;
		}
	}
}