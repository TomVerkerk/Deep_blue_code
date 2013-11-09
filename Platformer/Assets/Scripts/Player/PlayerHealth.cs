using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	public float playerHealth;
	public AudioClip powerup;
	

	void Update () 
	{
		if ( playerHealth <= 0) 
		{
			Application.LoadLevel("Menu");
		}
		if (playerHealth > 100)
		{
			playerHealth = 100;	
		}
	}
	
	public void TakeDamage (float damage)
	{
		playerHealth = playerHealth - damage;	
	}
	public void GainHealth(int hp)
	{
		audio.PlayOneShot(powerup);
		playerHealth = playerHealth + hp;	
	}
}
