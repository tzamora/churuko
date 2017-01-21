using UnityEngine;
using System.Collections;

public class GameContext : MonoSingleton<GameContext> {

	public GameObject player;

	public int EnergyBlocksDestroyed = 0;

	void OnGUI(){
		
		if (GUILayout.Button ("Restart")) {
			
			Application.LoadLevel(0);
			
		}

	}
}
