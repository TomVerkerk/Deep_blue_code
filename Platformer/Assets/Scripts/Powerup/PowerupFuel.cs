using UnityEngine;
using System.Collections;

public class PowerupFuel : MonoBehaviour {
	
	public Powerup_animation animator;
	public PlayerMove playerMove;
	public int gainFuel;
	public int fps;
	
	void Update() {
		animator.Animate(8,6,48,fps);
	}
	
	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.name == "Player" && playerMove._fuel < playerMove._maxFuel)
		{
			Destroy(gameObject);
			playerMove.GainFuel(gainFuel);	
		}
	}
			
}
