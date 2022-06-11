using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

	public enum CollectibleTypes {SmallHealthPickup, LargeHealthPickup, SilverCoin, GoldCoin, SilverBars, GoldBars}; // you can replace this with your own labels for the types of collectibles in your game!

	public CollectibleTypes CollectibleType; // this gameObject's type

	public bool rotate; // do you want it to rotate?

	public float rotationSpeed;

	public AudioClip collectSound;

	public GameObject collectEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Collect ();
		}
	}

	public void Collect()
	{
		if(collectSound)
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		//Below is space to add in your code for what happens based on the collectible type

		if (CollectibleType == CollectibleTypes.SmallHealthPickup) {

			var player = GameObject.FindWithTag("Player");
			var comp = player.GetComponent<Health>();
			comp.currentHealth = comp.currentHealth + 25;
			if (comp.currentHealth > comp.maxHealth)
			{
				comp.currentHealth = comp.maxHealth;
			}

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.LargeHealthPickup) {

			//Add in code here;
			var player = GameObject.FindWithTag("Player");
			var comp = player.GetComponent<Health>();
			comp.currentHealth = comp.currentHealth + 50;
			if (comp.currentHealth > comp.maxHealth)
			{
				comp.currentHealth = comp.maxHealth;
			}

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.SilverCoin) {

			//Add in code here;
			AddScore(1000);
		}
		if (CollectibleType == CollectibleTypes.GoldCoin) {

			//Add in code here;
			AddScore(2000);
			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.SilverBars) {

			//Add in code here;
			AddScore(5000);
			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.GoldBars) {

			//Add in code here;
			AddScore(10000);
			Debug.Log ("Do NoType Command");
		}

		Destroy (gameObject);
	}

	void AddScore(int value) 
	{
		var score = GameObject.FindWithTag("Score");
		var comp = score.GetComponent<ScoreManager>();
		comp.score = comp.score + value;
		ScoreManager.instance.AddPoints();
	}

}
