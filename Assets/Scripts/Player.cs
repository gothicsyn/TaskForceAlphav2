// <summary>
/// Player.cs
/// 11-01-14
/// M A Plant
/// 
/// This is the controller for the player object
/// </summary>
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Sets the available player states
	enum State {
		Playing,
		Explosion,
		Invincible
	}

	private State state = State.Playing;

    public float playerSpeed;
	public GameObject ProjectilePrefab;
	public GameObject ExplosionPrefab;
	public GameObject ShieldMesh;
	public KeyCode ShieldKey;

	public static int Score = 0;
	public static int Lives = 3;
	public static int Missed = 00;
	public static int Health = 100;
	public static bool shieldOn = false;
	public static int Shields = 2;

	private float projectileOffset = 1f;
	private float shipInvisibleTime = 1.5f;
	private float shipScreenSlide = 5f;
	private float shipBlink = 0.2f;
	private int numberOfBlinks = 10;
	private int blinkCount;

    void Update(){
		if (state != State.Explosion){
				float amtToMove = Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime;

     			// Move the Player
    			transform.Translate (Vector3.right * amtToMove);

   			 // Wrap
   		 	if (transform.position.x <= -7.5f)
        		transform.position = new Vector3(7.4f, transform.position.y, transform.position.z);
       		else if (transform.position.x >= 7.5f)
        		transform.position = new Vector3(-7.4f, transform.position.y, transform.position.z);

			//Fire Projectile
			if (Input.GetKeyDown("space")) {
				Vector3 position = new Vector3 (transform.position.x, transform.position.y + projectileOffset);
				Instantiate (ProjectilePrefab, position, Quaternion.identity);
			}
			
			//Fire Projectile Joypad
			if (Input.GetButtonDown("Fire")) {
				Vector3 position = new Vector3 (transform.position.x, transform.position.y + projectileOffset);
				Instantiate (ProjectilePrefab, position, Quaternion.identity);
			}

			// Create and Utilise the shield
			if (Input.GetKeyDown(ShieldKey)){
				if (!shieldOn){
					GameObject clone = (GameObject)Instantiate (ShieldMesh, transform.position, transform.rotation);
					clone.transform.parent = gameObject.transform;
					shieldOn = true;
			}
		}
			// Create and Utilise the shield Joypad
			if (Input.GetButtonDown("Shield")){
				if (!shieldOn){
					GameObject clone = (GameObject)Instantiate (ShieldMesh, transform.position, transform.rotation);
					clone.transform.parent = gameObject.transform;
					shieldOn = true;
			}
		}
	}
}

	// Sets collision events
	void OnTriggerEnter(Collider otherObject){
		if (otherObject.tag == "enemy"  && state == State.Playing){
			Player.Lives -= 1;
			Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
			enemy.SetPositionAndSpeed();	

			StartCoroutine (DestroyShip());
		}
	}

	// Destroys the ship and respawns the player
	IEnumerator DestroyShip(){
		state = State.Explosion;
			Instantiate (ExplosionPrefab, transform.position, Quaternion.identity);
			gameObject.GetComponent<Renderer>().enabled = false;
			transform.position = new Vector3 (0f, -5.5f, transform.position.z);
				yield return new WaitForSeconds (shipInvisibleTime);
		if (Player.Lives >= 0){
		
			// Respawns the player
			gameObject.GetComponent<Renderer>().enabled = true;
			while (transform.position.y < -2.3){
			
				// Reset player position using this respawn system
				float amtToMove = shipScreenSlide * Time.deltaTime;
				transform.position = new Vector3 (0f, transform.position.y + amtToMove, transform.position.z);

				yield return 0;
			}
			
			// Makes the player invincible
			state = State.Invincible;
			while (blinkCount < numberOfBlinks){
				gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
					if (gameObject.GetComponent<Renderer>().enabled == true)
					blinkCount ++;
			
			// Sets the "Blink Rate" of invincibility
				yield return new WaitForSeconds (shipBlink);
			}
			blinkCount = 0;
			state = State.Playing;
		}
		else 
			Application.LoadLevel("Loss");
	}
}