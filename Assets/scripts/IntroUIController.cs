using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using matnesis.TeaTime;
using UnityEngine.SceneManagement;

public class IntroUIController : MonoBehaviour {

	public Text titleText;

	public Button StartGameButton;

	public Button HelpButton;

	public Button AboutButton;

	public Button AboutBackButton;

	public Button HelpBackButton;

	public AudioClip IntroMusic;

	public GameObject effectWave;

	//
	//
	//

	public GameObject AboutPanel;

	public GameObject HelpPanel;

	public GameObject MenuPanel;

	// Use this for initialization
	void Start () {

		SoundManager.Get.PlayClip (IntroMusic, true);

		titleText.color = new Color (1f, 1f, 1f, 0f);

		this.tt ("TitleEntrance").Add(2f).Loop (4f, t => {
		
			titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, Mathf.Lerp(0f, 1f, t.t));
		
		}).Add(()=>{
			MenuPanel.SetActive(true);
		});

		StartGameButton.onClick.AddListener(delegate() {

			SceneManager.LoadScene ("LevelIntro");

		});

		AboutButton.onClick.AddListener(delegate() {

			MenuPanel.SetActive(false);
			AboutPanel.SetActive(true);

		});

		AboutBackButton.onClick.AddListener(delegate() {
			AboutPanel.SetActive(false);
			MenuPanel.SetActive(true);

		});

		HelpButton.onClick.AddListener(delegate() {

			MenuPanel.SetActive(false);
			HelpPanel.SetActive(true);

		});

		HelpBackButton.onClick.AddListener(delegate() {

			HelpPanel.SetActive(false);
			MenuPanel.SetActive(true);

		});

	}
}
