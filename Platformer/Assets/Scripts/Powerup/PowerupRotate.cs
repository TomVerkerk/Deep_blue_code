using UnityEngine;
using System.Collections;

public class PowerupRotate : MonoBehaviour {
	
	public float Xrotation;
	public float Yrotation;
	public float Zrotation;

	void Update () 
	{
		transform.Rotate(Xrotation * Time.deltaTime,Yrotation * Time.deltaTime,Zrotation * Time.deltaTime);
	}
}
