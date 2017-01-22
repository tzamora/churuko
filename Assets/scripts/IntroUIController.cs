using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using matnesis.TeaTime;

public class IntroUIController : MonoBehaviour {

	public Text titleText;

	public Button StartGameButton;

	public Button ArenaButton;

	public Button AboutButton;

	public AudioClip IntroMusic;

	// Use this for initialization
	void Start () {

		SoundManager.Get.PlayClip (IntroMusic, true);

		titleText.color = new Color (1f, 1f, 1f, 0f);

		this.tt ("TitleEntrance").Add(2f).Loop (7f, t => {
		
			titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, Mathf.Lerp(0f, 1f, t.t));

		}).Add(1,t=>{
			
			StartGameButton.enabled = false;

			ArenaButton.enabled = true;

			AboutButton.enabled = true;
		});

	}
}
