using UnityEngine;
using System.Collections;

public class MenuStart: MonoBehaviour {
	
	public Texture2D cursorTexture;
	//private CursorMode cursormodee;
	//private Vector2 hotSpot;
	public AudioClip background;
	
	void Start ()
	{
		//cursormodee = CursorMode.Auto;
		//hotSpot = Vector2.zero;
		audio.PlayOneShot(background);
	}
	
	void OnGUI() 
	{
		GUI.backgroundColor = Color.clear;
		

			
		if(GUI.Button(new Rect(35,410,200,80),""))
		{
			Application.LoadLevel("Level1");
		}
		if(GUI.Button(new Rect(275,400,290,100),""))
		{
			Application.LoadLevel ("Options");
		}
		if(GUI.Button(new Rect(635,400,280,100),""))
		{
			Application.LoadLevel("Credits");
		}
		if(GUI.Button(new Rect(770,90,150,30),""))
		{
			Application.LoadLevel ("Controls");
		}
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();	
		}
	}
	void OnMouseEnter()
	{
		//Cursor.SetCursor(cursorTexture, hotSpot, cursormodee);
		Debug.Log(":O");	
	}
	
	void OnMouseExit ()
	{
		//Cursor.SetCursor(null, Vector2.zero, cursormodee);	
	}
}
