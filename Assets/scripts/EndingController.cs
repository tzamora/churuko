using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using matnesis.TeaTime;
using Exploder.Utils;
using UnityEngine.SceneManagement;


public class EndingController : MonoBehaviour {

	public ColliderController endingTrigger;

	public GameObject reactor;

	public AudioClip reactorSound;

	public Text finalText;

	// Use this for initialization
	void Start () {

		endingTrigger.TriggerEnter += (Collider collider) => {

			Vector3 playerPosition = GameContext.Get.player.transform.position;

			SoundManager.Get.PlayClip(reactorSound, false);

			Camera.main.transform.parent = null;

			this.tt().Add(1f, ()=>{

				//ExploderSingleton.ExploderInstance.ExplodeObject (GameContext.Get.player);
			});

			this.tt("MoveCamera").Loop(10f, t=>{

				Camera.main.transform.position = 
					Vector3.Lerp(playerPosition, reactor.transform.position, t.t);

			}).Add(3f, ()=>{
				SceneManager.LoadScene("Intro");
			});

			this.tt().Add(7f, t=>{
				
				Camera.main.GetComponent<FadeInOut>().fadeDirection = 1;
			
			});

			//Color currentColor = finalText.color;
				
			this.tt().Add(2f).Loop (4f, t => {
				//finalText.color = Color.
				finalText.color = new Color(finalText.color.r, finalText.color.g, finalText.color.b, Mathf.Lerp(0f, 1f, t.t));

				//print("---> " + finalText.color);

			});


		};

	}
}
