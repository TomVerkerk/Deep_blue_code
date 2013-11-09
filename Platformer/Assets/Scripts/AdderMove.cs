using UnityEngine;
using System.Collections;

public class AdderMove : MonoBehaviour {
	
	private AdderAnimationL adderL;
	private AdderAnimationR adderR;
	public EnemyHealth enemyhealth;
	private BasicFishL basicL;
	private BasicFishR basicR;
	public PlayerHealth playerhealth;
	
	public int fps;
	public int back;
	public int turn;
	
	public float damage;
	public int maxDistanceX;
	public int maxDistanceY;
	public int damageDistanceX;
	public int damageDistanceY;
	public float attackFactor;
	public float extraRoomX;
	public float extraRoomY;
	public float movementSpeed;
	public AudioClip adder;
	private bool played;
	
	// Use this for initialization
	void Start () {
		played = false;
		enemyhealth = GetComponent<EnemyHealth>();
		adderL = GetComponent<AdderAnimationL>();
		adderR = GetComponent<AdderAnimationR>();
		basicL = GetComponent<BasicFishL>();
		basicR = GetComponent<BasicFishR>();
	}
	
	void Update() {
		int time = (int)Time.time % back;
		
		float adderPositionX = rigidbody.position.x;
		float adderPositionY = rigidbody.position.y;
		float distanceX = adderPositionX - PlayerMove.playerPositionX;
		float distanceY = adderPositionY - PlayerMove.playerPositionY;
		
		// Mike code
		
		//
		if(distanceX <= maxDistanceX && distanceX >= -maxDistanceX && distanceY <= maxDistanceY && distanceY >= -maxDistanceY || enemyhealth.hitEnemy == true)
		{
			if(played == false)
			{
				audio.PlayOneShot(adder);
				played = true;
			}
			if(played == true)
			{
				Vector2 movement = new Vector2(extraRoomX-distanceX,extraRoomY-distanceY);
				transform.Translate(movement * (movementSpeed*attackFactor) * Time.deltaTime);
				if(distanceX <= 0)
				{
					adderL.Animate(4,8,32,fps);
				}
				else if (distanceX >= 0)
				{
					adderR.Animate(4,8,32,-fps);
				}
			}
			if(distanceX <= damageDistanceX && distanceX >= -damageDistanceX && distanceY <= damageDistanceY && distanceY >= -damageDistanceY)
			{
				playerhealth.TakeDamage(Time.time/100*damage);	
			}
		}
		else
		{
			played = false;
			if(time <= turn)
			{
				transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
				basicL.Animate(4,7,28,-fps);
			}
			else
			{
			
				transform.Translate(-Vector2.right * movementSpeed * Time.deltaTime);
				basicR.Animate(4,7,28,fps);
			}
		}
	}
}