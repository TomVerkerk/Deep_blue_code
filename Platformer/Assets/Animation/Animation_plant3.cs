using UnityEngine;
using System.Collections;

public class Animation_plant3 : MonoBehaviour {
	
	public int startFrame;
	float offsetX;
	float offsetY;
	public float extraOffsetX;
	public float extraOffsetY;
	private Texture2D myTexture;
	public int fps;

	public void Animate(int Columns, int Rows, int Cells, int Fps)
	{
		int index = (int)(Fps * Time.time);
		index = ((index + startFrame) % Cells);
		
		float rightX = 1f /Columns;
		float rightY = 1f /Rows;
		Vector2 size = new Vector2(rightX, rightY);
		
		myTexture = new Texture2D((int)rightX, (int)rightY);
		myTexture = Resources.Load("plant3", typeof(Texture2D)) as Texture2D;
		
		float uIndex = index % Columns;
		float vIndex = index/Columns;
		
		offsetX = uIndex * rightX + extraOffsetX;
		offsetY = 1 + extraOffsetY -(vIndex * rightY);
		
		Vector2 offset = new Vector2(offsetX, offsetY);
		
		renderer.material.mainTexture = myTexture;
		renderer.material.SetTextureScale("_MainTex", size);
		renderer.material.SetTextureOffset("_MainTex", offset);
	}
	
	void Update ()
	{
		Animate(5,7,35,fps);
	}
}
