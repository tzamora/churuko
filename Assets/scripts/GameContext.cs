using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using matnesis.TeaTime;

public class GameContext : MonoSingleton<GameContext> {

	public GameObject player;

	public GameObject DieMenuPanel;

	public int EnergyBlocksDestroyed = 0;

	void OnGUI(){
		
		if (GUILayout.Button ("Restart")) {
			
			Application.LoadLevel(0);
			
		}

	}
}
