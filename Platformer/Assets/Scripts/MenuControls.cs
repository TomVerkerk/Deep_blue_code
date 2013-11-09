using UnityEngine;
using System.Collections;

public class MenuControls : MonoBehaviour {

	public GUISkin mySkin;
	
	void OnGUI()
	{
	//	GUI.skin = mySkin;	
		
	//	GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200,325),"Options");
		
	//	if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100,100,50),"Back"))
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel("Menu");
		}
	}
}
