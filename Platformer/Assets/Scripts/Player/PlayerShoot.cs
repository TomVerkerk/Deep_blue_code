using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	
	public Rigidbody Bullet;
	public int _fps;
	private float _time;
	private bool _canShoot = true;
	private bool _isTiming;
	public AudioClip shoot;
	public float bulletSpeed;
	public PlayerMove playermove;
	public Animation_shoot sprShoot;
	public Animation_shoot_L sprShootL;
	public bool shooting = false;
	public float shoottime;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// Timer
		if(_isTiming)
		{
			_time += Time.deltaTime;	
		}
		if (_time >= shoottime)
		{
			_canShoot = true;
			_isTiming = false;
			shooting = false;
		}
		
		if(shooting == true && playermove.left == false)
		{
			sprShootL.Animate(6,3,18,-_fps);
		}
		if(shooting == true && playermove.left == true)
		{
			sprShoot.Animate(6,3,18,_fps);
		}
		// Shoot bullets
		if(Input.GetAxis("Fire1") == 1 && (_canShoot))
		{
			Rigidbody clone;
			Vector2 left = new Vector2(1,0);
			Vector2 right = new Vector2(-1,0);
			Vector2 negative = new Vector2(-1,-1);
			clone = Instantiate(Bullet, transform.position, transform.rotation) as Rigidbody;
			if(playermove.left == true)
			{
            	clone.velocity = transform.TransformDirection(left * bulletSpeed * Time.deltaTime);
				//sprShootL.Animate(4,6,24,-_fps);
			}
			if(playermove.left == false)
			{
				clone.velocity = transform.TransformDirection(right * bulletSpeed * Time.deltaTime);
				clone.renderer.material.SetTextureScale("_MainTex", negative);
				//sprShoot.Animate(4,6,24,_fps);
			}
			beginTimer();
			audio.PlayOneShot(shoot);
			_canShoot = false;
			shooting = true;
			
			// shooting animation
		}
		else
		{
			// normal animation
		}
	}
	
	void beginTimer()
	{		
		_time = 0;
		_isTiming = true;
	}
}
