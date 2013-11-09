using UnityEngine;
using System.Collections;

public class ButtonAnimator : MonoBehaviour {
	
	public float offsetY;
	
	public GateAnimator gate;
	
	public void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name == "Player")
		{
			Vector2 button = new Vector2(0f, offsetY);
			transform.Translate(button);
			gate.Animate();
		}
	}
}
