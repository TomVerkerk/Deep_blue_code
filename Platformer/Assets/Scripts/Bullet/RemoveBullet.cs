using UnityEngine;
using System.Collections;

public class RemoveBullet : MonoBehaviour {
	
	public float lifeTime = 2;
	// Use this for initialization
	void Update () {
		if(Time.time >= lifeTime)
		{
		Destroy(gameObject, lifeTime);
		}
	}
}