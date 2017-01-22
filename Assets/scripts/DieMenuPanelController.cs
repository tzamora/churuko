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

			//Scene scene = SceneManager.GetActiveScene();

			GameContext.Get.resetLevel();

			GameContext.Get.DieMenuPanel.SetActive(false);


		});

		menuButton.onClick.AddListener (()=>{

			SceneManager.LoadScene("Intro");

		});

	}
}
