using UnityEngine;
using System.Collections;

public class PowerupHP : MonoBehaviour {

	public PlayerHealth playerHealth;
	public int powerupHealth;
		
	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.name == "Player" && playerHealth.playerHealth < 100)
		{
			Destroy(gameObject);
			playerHealth.GainHealth(powerupHealth);	
		}
	}
			
}
