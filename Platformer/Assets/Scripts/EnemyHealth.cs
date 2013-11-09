using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float enemyHealth;
	public int playerDamage;
	public bool hitEnemy;
	
	void Start () {
		hitEnemy = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( enemyHealth <= 0) 
		{
			Destroy(gameObject);
		}
	}
	
	public void EnemyTakeDamage(int playerDamage)
	{
		enemyHealth = enemyHealth - playerDamage;
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Bullet")
		{
			hitEnemy = true;
			Destroy(col.gameObject);	
			EnemyTakeDamage(playerDamage);
		}
	}
	
}
