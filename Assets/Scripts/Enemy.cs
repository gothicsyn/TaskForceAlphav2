// <summary>
/// Enemy.cs
/// 12-01-14
/// M A Plant
/// 
/// This is the controller for enemy asteroid behaviours
/// </summary>
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float MinSpeed;
	public float MaxSpeed;

	public GameObject Shieldup;
	public GameObject Healthup;
	public GameObject Missdown;

	private float currentSpeed;
	private float currentRotateSpeed;
	private float currentScaleX;
	private float currentScaleY;
	private float currentScaleZ;

	private float minRotateSpeed = 55f;
	private float maxRotateSpeed = 130f;
	private float minScale = 0.1f;
	private float maxScale = 0.2f;
	
	private float x, y, z;

	// Use this for initialization
	void Start () {
		SetPositionAndSpeed();
	}
	
	// Update is called once per frame
	void Update () {

		// Sets the rotate rate of an object
		float rotatespeed = currentRotateSpeed * Time.deltaTime;
		transform.Rotate (new Vector3(-1, 0, 0) * rotatespeed);

		// Sets the rate at which an object moves down screen
		float amtToMove = currentSpeed * Time.deltaTime;
		transform.Translate (Vector3.down * amtToMove, Space.World);

		// Destroys the object once it leaves the visual range of the game
		if (transform.position.y <= -5){
		SetPositionAndSpeed();
			Player.Missed ++;
		}
	}

	// Resets and respawns an enemy
	public void SetPositionAndSpeed(){
	
		currentRotateSpeed = Random.Range (minRotateSpeed, maxRotateSpeed);
		currentScaleX = Random.Range (minScale, maxScale);
		currentScaleY = Random.Range (minScale, maxScale);
		currentScaleZ = Random.Range (minScale, maxScale);
		currentSpeed = Random.Range(MinSpeed, MaxSpeed);

		x = Random.Range(-6f, 6f);
		y = 7.0f;
		z = 0.0f;
		
		transform.position = new Vector3(x, y, z);

		transform.localScale = new Vector3 (currentScaleX, currentScaleY, currentScaleZ);
	}

	// Sets the conditions for a power up to spawn
	public void PowerUpSpawn (){
		if(GameObject.FindGameObjectsWithTag("Shieldup").Length == 0){
			if(Random.Range(1, 8) == 1){
				Instantiate(Shieldup, transform.position, transform.rotation);
				return;	
			}	
		}

		if(GameObject.FindGameObjectsWithTag("Healthup").Length == 0){
			if(Random.Range(1, 10) == 3){
				Instantiate(Healthup, transform.position, transform.rotation);
				return;	
			}	
		}

		if(GameObject.FindGameObjectsWithTag("Missdown").Length == 0){
			if(Random.Range(1, 10) == 8){
				Instantiate(Missdown, transform.position, transform.rotation);
				return;	
			}	
		}
	}
}