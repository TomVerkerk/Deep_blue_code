using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour 
{
 public float scrollSpeed;

 void Update () {
		float x = Input.GetAxis("Horizontal");
		
		if(x != 0)
		{
		Vector2 offset = new Vector2(-x * scrollSpeed * Time.deltaTime, 0f);
		renderer.material.SetTextureOffset("_MainTex", offset);
		}
	}
}
