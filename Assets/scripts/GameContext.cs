using UnityEngine;
using System.Collections;

public class GameContext : MonoBehaviour {

	public GameObject player;

	void OnGUI(){
		
		if (GUILayout.Button ("Restart")) {
			
			Application.LoadLevel(0);
			
		}

	}
}
