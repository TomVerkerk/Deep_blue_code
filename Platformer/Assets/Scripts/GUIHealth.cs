using UnityEngine;
using System.Collections;

public class GUIHealth : MonoBehaviour {
	
	public PlayerHealth other;
	
	string text;
	
	void Update () {
			guiText.text = 	"" + (int)other.playerHealth;
	}
}
