using UnityEngine;
using System.Collections;

public class GUIFuel : MonoBehaviour {
	
	public PlayerMove move;
	
	string text;
	
	void Update () 
	{
		guiText.text = 	"" + (int)move._fuel;
	}
}
