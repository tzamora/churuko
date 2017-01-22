using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DieMenuPanelController : MonoBehaviour {

	public Button restartButton;

	public Button menuButton;

	// Use this for initialization
	void Start () {

		restartButton.onClick.AddListener (()=>{

			Scene scene = SceneManager.GetActiveScene();

			SceneManager.LoadScene(scene.name);

		});

		menuButton.onClick.AddListener (()=>{



		});

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
