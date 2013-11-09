using UnityEngine;
using System.Collections;

public class SpriteAnimator : MonoBehaviour {
	
	float offsetX;
	float offsetY;
	
	public void Animate(int Columns, int Rows, int Cells, int Fps)
	{
		int index = (int)(Fps * Time.time);
		index = index % Cells;
		
		float sizeX = 1f /Columns;
		float sizeY = 1f /Rows;
		Vector2 size = new Vector2(sizeX, sizeY);
		
		float uIndex = index % Columns;
		float vIndex = index/Columns;
		
		offsetX = uIndex * sizeX;
		offsetY = 1-(vIndex * sizeY);
		
		Vector2 offset = new Vector2(offsetX, offsetY);
		
		renderer.material.SetTextureScale("_MainTex", size);
		renderer.material.SetTextureOffset("_MainTex", offset);
		
		Debug.Log(index);
	}
}
