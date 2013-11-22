using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name == "Player")
		{
			Application.LoadLevel("Menu");
		}
	}
}
