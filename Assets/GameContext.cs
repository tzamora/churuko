using UnityEngine;
using System.Collections;

public class GameContext : MonoBehaviour {

	void OnGUI(){

		if (GUILayout.Button ("Restart")) {
			
			Application.LoadLevel(0);
			
		}

	}
}
