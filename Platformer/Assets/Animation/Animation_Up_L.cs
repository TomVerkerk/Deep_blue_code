using UnityEngine;
using System.Collections;

public class Animation_Up_L : MonoBehaviour {

	float offsetX;
	float offsetY;
	public float extraOffsetX;
	public float extraOffsetY;
	private Texture2D myTexture;
	
	public void Animate(int Columns, int Rows, int Cells, int Fps)
	{
		int index = (int)(Fps * Time.time);
		index = index % Cells; 
		
		float leftX = 0-(1f /Columns);
		float leftY = 1f /Rows;
		Vector2 negative = new Vector2(leftX,leftY);
		
		myTexture = new Texture2D((int)leftX, (int)leftY);
		myTexture = Resources.Load("upward", typeof(Texture2D)) as Texture2D;
		
		float uIndex = (index % Columns) - 1;
		float vIndex = index/Columns;
		
		offsetX = uIndex * leftX + extraOffsetX;
		offsetY = vIndex * leftY + extraOffsetY;
		
		Vector2 offset = new Vector2(offsetX, offsetY);
		
		renderer.material.mainTexture = myTexture;
		renderer.material.SetTextureScale("_MainTex", negative);
		renderer.material.SetTextureOffset("_MainTex", offset);
	}
}