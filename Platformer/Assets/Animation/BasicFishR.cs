﻿using UnityEngine;
using System.Collections;

public class BasicFishR : MonoBehaviour {
	
	float offsetX;
	float offsetY;
	public float extraOffsetX;
	public float extraOffsetY;
	private Texture2D myTexture;
	
	public void Animate(int Columns, int Rows, int Cells, int Fps)
	{
		int index = (int)(Fps * Time.time);
		index = index % Cells;
		
		float rightX = 1f /Columns;
		float rightY = 1f /Rows;
		Vector2 size = new Vector2(rightX, rightY);
		
		myTexture = new Texture2D((int)rightX, (int)rightY);
		myTexture = Resources.Load("swimmingfish", typeof(Texture2D)) as Texture2D;
		
		float uIndex = index % Columns;
		float vIndex = index/Columns;
		
		offsetX = uIndex * rightX + extraOffsetX;
		offsetY = 1 + extraOffsetY -(vIndex * rightY);
		
		Vector2 offset = new Vector2(offsetX, offsetY);
		
		renderer.material.mainTexture = myTexture;
		renderer.material.SetTextureScale("_MainTex", size);
		renderer.material.SetTextureOffset("_MainTex", offset);
	}
}
