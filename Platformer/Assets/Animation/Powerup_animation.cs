using UnityEngine;
using System.Collections;

public class Powerup_animation : MonoBehaviour {
	
	float offsetX;
	float offsetY;
	public float extraOffsetX;
	public float extraOffsetY;

	public void Animate(int Columns, int Rows, int Cells, int Fps)
	{
		int index = (int)(Fps * Time.time);
		index = index % Cells;
		
		float rightX = 1f /Columns;
		float rightY = 1f /Rows;
		Vector2 size = new Vector2(rightX, rightY);
		
		float uIndex = index % Columns;
		float vIndex = index/Columns;
		
		offsetX = uIndex * rightX + extraOffsetX;
		offsetY = 1 + extraOffsetY -(vIndex * rightY);
		
		Vector2 offset = new Vector2(offsetX, offsetY);
		
		renderer.material.SetTextureScale("_MainTex", size);
		renderer.material.SetTextureOffset("_MainTex", offset);
	}
}
