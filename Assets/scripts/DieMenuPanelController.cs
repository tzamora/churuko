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

			print("pero que putas");

			Scene scene = SceneManager.GetActiveScene();

			SceneManager.LoadScene(scene.name);

		});

		menuButton.onClick.AddListener (()=>{



		});

	}
}
