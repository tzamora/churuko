using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWarpController : MonoBehaviour {

	public ColliderController warpTrigger;

	public string levelName;

	public Text levelNumberText;

	public int levelNumber;

	// Use this for initialization
	void Start () {

		levelNumberText.text = "" + levelNumber;

		warpTrigger.TriggerEnter += (Collider collider) => {

			if(collider.GetComponent<PlayerController>()){
			
				SceneManager.LoadScene (levelName);

			}

		};

	}
}
