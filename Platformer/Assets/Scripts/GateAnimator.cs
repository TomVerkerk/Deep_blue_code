using UnityEngine;
using System.Collections;

public class GateAnimator : MonoBehaviour {
	
	public float up;
	
	public void Animate()
	{
		Vector2 movement = new Vector2(0f, up);
		transform.Translate(movement);
	}
}