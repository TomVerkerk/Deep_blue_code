using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	private AnimationR sprRight;
	private AnimationL sprLeft;
	private Animation_Up sprUp;
	private Animation_Up_L sprUpL;
	private Animation_Idle sprIdle;
	private Animation_Idle_L sprIdleL;
	private Animation_Down sprDown;
	private Animation_Down_L sprDownL;
	private PlayerHealth playerhealth;
	public PlayerShoot playershoot;
	
	public float _fuel;
	public int _fuelLoss;
	public float _rechargeRate;
	public int _maxFuel;
	private float _movementSpeed;
	public int _jetPower;
	public float sprintSpeed;
	public float normalSpeed;
	
	public int maxDepth;
	public float DepthDamage;
		
	public int _fps;
	
	private float playerx;
	private float playery;
	private float spotL1x;
	private float spotL1y;
	private float spotL1z;
	private float spotL2x;
	private float spotL2y;
	private float spotL2z;
	private float spotR1x;
	private float spotR1y;
	private float spotR1z;
	private float spotR2x;
	private float spotR2y;
	private float spotR2z;
	
	public bool left;
	public static float playerPositionX;
	public static float playerPositionY;
	public static bool _facingRight;
	private bool _useJetpack;
	public AudioClip BackGround;
	public AudioClip Rotor;
	public AudioClip powerup;
	public GameObject spotL1;
	public GameObject spotL2;
	public GameObject spotR1;
	public GameObject spotR2;
	private bool lightOn;
	
	private bool _canShoot = true;
	private bool _isTiming;
	private float _time;
	
	void Start () {
		lightOn = true;
		left = false;
		spotL1.light.color = Color.white;
		spotL2.light.color = Color.white;
		spotR1.light.color = Color.clear;
		spotR2.light.color = Color.clear;
		_movementSpeed = normalSpeed;
		audio.PlayOneShot(BackGround);
		playerhealth = GetComponent<PlayerHealth>();
		sprRight = GetComponent<AnimationR>();
		sprLeft = GetComponent<AnimationL>();
		sprUp = GetComponent<Animation_Up>();
		sprUpL = GetComponent<Animation_Up_L>();
		sprIdle = GetComponent<Animation_Idle>();
		sprIdleL = GetComponent<Animation_Idle_L>();
		sprDown = GetComponent<Animation_Down>();
		sprDownL = GetComponent<Animation_Down_L>();
	}
	
	void Update () {
		
		playerx = gameObject.rigidbody.position.x;
		playery = gameObject.rigidbody.position.y;
		spotL1x = spotL1.light.transform.position.x;
		spotL1y = spotL1.light.transform.position.y;
		spotL1z = (float)7.25;
		spotL2x = spotL2.light.transform.position.x;
		spotL2y = spotL2.light.transform.position.y;
		spotL2z = (float)-1.457983;
		spotR1x = spotR1.light.transform.position.x;
		spotR1y = spotR1.light.transform.position.y;
		spotR1z = (float)7.25;
		spotR2x = spotR2.light.transform.position.x;
		spotR2y = spotR2.light.transform.position.y;
		spotR2z = (float)-1.457983;
		
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel("Menu");
		}
		
		playerPositionX = rigidbody.position.x;
		playerPositionY = rigidbody.position.y;
			
		if(_fuel < _maxFuel && _useJetpack == false)
		{ 
			_fuel += _rechargeRate;
		}
		if(_fuel > _maxFuel)
		{
			_fuel = _maxFuel;	
		}
		
		if(rigidbody.position.y <= maxDepth)
		{
			playerhealth.TakeDamage(Time.time/100*DepthDamage);
		}
		
		if(Input.GetKey(KeyCode.LeftShift))
		{
			_movementSpeed = sprintSpeed;
		}
		else
		{
			_movementSpeed = normalSpeed;
		}
		
		if(_isTiming)
		{
			_time += Time.deltaTime;	
		}
		if (_time >= 0.4)
		{
			_canShoot = true;
			_isTiming = false;
		}
	}
	
	public void GainFuel(int fuel)
	{
		audio.PlayOneShot(powerup);
		_fuel = _fuel + fuel;
	}
	
	void FixedUpdate()
	{	
		//Moving Right
		if(Input.GetAxis("Horizontal") == 1)
		{	
			transform.Translate(-Vector3.right * _movementSpeed * Time.deltaTime);
			if(playershoot.shooting == true)
			{
				//is shooting
			}
			if(playershoot.shooting == false)
			{
				if(Input.GetAxis("Vertical") == -1)
				{
					spotL2.light.transform.LookAt(new Vector3(spotL2x+1,spotL2y-1,spotL2z));
					spotL1.light.transform.LookAt(new Vector3(spotL1x+1,spotL1y-1,spotL1z));
					spotL2.light.transform.position = (new Vector3(playerx-(float)1.85,playery+(float)1.85,spotL2z));
					spotL1.light.transform.position = (new Vector3(playerx-(float)1.85,playery+(float)1.85,spotL1z));
					sprDown.Animate(2,1,2,_fps);
				}
				if(Input.GetAxis("Vertical") == 0)
				{
					spotL2.light.transform.LookAt(new Vector3(spotL2x+1,spotL2y,spotL2z));
					spotL1.light.transform.LookAt(new Vector3(spotL1x+1,spotL1y,spotL1z));
					spotL2.light.transform.position = (new Vector3(playerx-(float)2.53,playery,spotL2z));
					spotL1.light.transform.position = (new Vector3(playerx-(float)2.53,playery,spotL1z));
					sprRight.Animate(3,2,6,_fps);
				}
				if(Input.GetAxis("Vertical") == 1)
				{
					spotL2.light.transform.LookAt(new Vector3(spotL2x+1,spotL2y+1,spotL2z));
					spotL1.light.transform.LookAt(new Vector3(spotL1x+1,spotL1y+1,spotL1z));
					spotL2.light.transform.position = (new Vector3(playerx-(float)1.85,playery-(float)1.85,spotL2z));
					spotL1.light.transform.position = (new Vector3(playerx-(float)1.85,playery-(float)1.85,spotL1z));
					sprUp.Animate(2,1,2,_fps);
				}
			}
			audio.PlayOneShot(Rotor);
			if(lightOn == true)
			{
				spotL1.light.color = Color.white;
				spotL2.light.color = Color.white;
				spotR1.light.color = Color.clear;
				spotR2.light.color = Color.clear;
			}
			else if(lightOn == false)
			{
				spotL1.light.color = Color.clear;
				spotL2.light.color = Color.clear;
				spotR1.light.color = Color.clear;
				spotR2.light.color = Color.clear;
			}
			left = false;
		}
		//Moving Left
		else if(Input.GetAxis("Horizontal") == -1)
		{
			transform.Translate(Vector3.right * _movementSpeed * Time.deltaTime );
			if(playershoot.shooting == true)
			{
				// is shooting
			}
			if(playershoot.shooting == false)
			{
				if(Input.GetAxis("Vertical") == -1)
				{
					spotR2.light.transform.LookAt(new Vector3(spotR2x-1,spotR2y-1,spotR2z));
					spotR1.light.transform.LookAt(new Vector3(spotR1x-1,spotR1y-1,spotR1z));
					spotR2.light.transform.position = (new Vector3(playerx+(float)1.85,playery+(float)1.85,spotR2z));
					spotR1.light.transform.position = (new Vector3(playerx+(float)1.85,playery+(float)1.85,spotR1z));
					sprDownL.Animate(2,1,2,-_fps);
				}
				if(Input.GetAxis("Vertical") == 0)
				{
					spotR2.light.transform.LookAt(new Vector3(spotR2x-1,spotR2y,spotR2z));
					spotR1.light.transform.LookAt(new Vector3(spotR1x-1,spotR1y,spotR1z));
					spotR2.light.transform.position = (new Vector3(playerx+(float)2.53,playery,spotR2z));
					spotR1.light.transform.position = (new Vector3(playerx+(float)2.53,playery,spotR1z));
					sprLeft.Animate(3,2,6,-_fps);
				}
				if(Input.GetAxis("Vertical") == 1)
				{
					spotR2.light.transform.LookAt(new Vector3(spotR2x-1,spotR2y+1,spotR2z));
					spotR1.light.transform.LookAt(new Vector3(spotR1x-1,spotR1y+1,spotR1z));
					spotR2.light.transform.position = (new Vector3(playerx+(float)1.85,playery-(float)1.85,spotR2z));
					spotR1.light.transform.position = (new Vector3(playerx+(float)1.85,playery-(float)1.85,spotR1z));
					sprUpL.Animate(2,1,2,-_fps);
				}
			}
			audio.PlayOneShot(Rotor);
			if(lightOn == true)
			{
				spotL1.light.color = Color.clear;
				spotL2.light.color = Color.clear;
				spotR1.light.color = Color.white;
				spotR2.light.color = Color.white;
			}
			else if(lightOn == false)
			{
				spotL1.light.color = Color.clear;
				spotL2.light.color = Color.clear;
				spotR1.light.color = Color.clear;
				spotR2.light.color = Color.clear;
			}
			left = true;
		}
		//Idle
		else if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
		{
			if(playershoot.shooting == true)
			{
				
			}
			if(playershoot.shooting == false)
			{
				if(left == true)
				{
					spotR2.light.transform.LookAt(new Vector3(spotR2x-1,spotR2y,spotR2z));
					spotR1.light.transform.LookAt(new Vector3(spotR1x-1,spotR1y,spotR1z));
					spotR2.light.transform.position = (new Vector3(playerx+(float)2.53,playery,spotR2z));
					spotR1.light.transform.position = (new Vector3(playerx+(float)2.53,playery,spotR1z));
					sprIdleL.Animate(2,1,2,-_fps);
				}
				if(left == false)
				{
					spotL2.light.transform.LookAt(new Vector3(spotL2x+1,spotL2y,spotL2z));
					spotL1.light.transform.LookAt(new Vector3(spotL1x+1,spotL1y,spotL1z));
					spotL2.light.transform.position = (new Vector3(playerx-(float)2.53,playery,spotL2z));
					spotL1.light.transform.position = (new Vector3(playerx-(float)2.53,playery,spotL1z));
					sprIdle.Animate(2,1,2,_fps);
				}
			}
		}
		//moving down
		else if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == -1)
		{
			if(playershoot.shooting == true)
			{
				
			}
			if(playershoot.shooting == false)
			{
				if(left == true)
				{
					spotR2.light.transform.LookAt(new Vector3(spotR2x-1,spotR2y-1,spotR2z));
					spotR1.light.transform.LookAt(new Vector3(spotR1x-1,spotR1y-1,spotR1z));
					spotR2.light.transform.position = (new Vector3(playerx+(float)1.85,playery+(float)1.85,spotR2z));
					spotR1.light.transform.position = (new Vector3(playerx+(float)1.85,playery+(float)1.85,spotR1z));
					sprDownL.Animate(2,1,2,-_fps);
				}
				if(left == false)
				{
					spotL2.light.transform.LookAt(new Vector3(spotL2x+1,spotL2y-1,spotL2z));
					spotL1.light.transform.LookAt(new Vector3(spotL1x+1,spotL1y-1,spotL1z));
					spotL2.light.transform.position = (new Vector3(playerx-(float)1.85,playery+(float)1.85,spotL2z));
					spotL1.light.transform.position = (new Vector3(playerx-(float)1.85,playery+(float)1.85,spotL1z));
					sprDown.Animate(2,1,2,_fps);
				}
			}
		}	
		// Moving Up
		if(_fuel > 0 && Input.GetAxis("Vertical") == 1)
		{
			_useJetpack = true;
			rigidbody.AddForce(Vector3.up * _jetPower * Time.deltaTime);
			_fuel = _fuel - _fuelLoss;
			audio.PlayOneShot(Rotor);
			if(playershoot.shooting == true)
			{
				
			}
			if(playershoot.shooting == false)
			{
				if(left == true)
				{
					spotR2.light.transform.LookAt(new Vector3(spotR2x-1,spotR2y+1,spotR2z));
					spotR1.light.transform.LookAt(new Vector3(spotR1x-1,spotR1y+1,spotR1z));
					spotR2.light.transform.position = (new Vector3(playerx+(float)1.85,playery-(float)1.85,spotR2z));
					spotR1.light.transform.position = (new Vector3(playerx+(float)1.85,playery-(float)1.85,spotR1z));
					sprUpL.Animate(2,1,2,-_fps);
				}
				if(left == false)
				{
					spotL2.light.transform.LookAt(new Vector3(spotL2x+1,spotL2y+1,spotL2z));
					spotL1.light.transform.LookAt(new Vector3(spotL1x+1,spotL1y+1,spotL1z));
					spotL2.light.transform.position = (new Vector3(playerx-(float)1.85,playery-(float)1.85,spotL2z));
					spotL1.light.transform.position = (new Vector3(playerx-(float)1.85,playery-(float)1.85,spotL1z));
					sprUp.Animate(2,1,2,_fps);
				}
			}
		}
		else _useJetpack = false;
		
		
		
		if(Input.GetKey(KeyCode.Space) && lightOn == true && _canShoot == true)
		{
			spotL1.light.color = Color.clear;
			spotL2.light.color = Color.clear;
			spotR1.light.color = Color.clear;
			spotR2.light.color = Color.clear;
			lightOn = false;
			_canShoot = false;
			beginTimer();
		}
		else if(Input.GetKey(KeyCode.Space) && lightOn == false && _canShoot == true)
		{
			if(left == true)
			{
				spotL1.light.color = Color.clear;
				spotL2.light.color = Color.clear;
				spotR1.light.color = Color.white;
				spotR2.light.color = Color.white;
				lightOn = true;
				_canShoot = false;
				beginTimer();
			}
			else if(left == false)
			{
				spotL1.light.color = Color.white;
				spotL2.light.color = Color.white;
				spotR1.light.color = Color.clear;
				spotR2.light.color = Color.clear;
				lightOn = true;
				_canShoot = false;
				beginTimer();
			}
		}
	}
	void beginTimer()
	{		
		_time = 0;
		_isTiming = true;
	}
}