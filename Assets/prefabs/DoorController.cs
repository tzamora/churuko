using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class DoorController : MonoBehaviour {

	public Transform OpenPosition;
	public bool OpenDoor = false;
	public float OpenTime = 3f;
	public float EnergyBlocksToOpen = 5f;
	public AudioClip DoorOpeningSound;

	public Camera doorCamera;


	// Use this for initialization
	void Start () {

		DoorStatusCheck ();

	}

	// Update is called once per frame
	void OpenDoorRoutine () {

		Vector3 startPos = transform.position;

		this.tt ().Add(delegate() {
			doorCamera.enabled = true;
		}).Loop (OpenTime, handler => {

			transform.position = Vector3.Lerp(startPos, OpenPosition.position, handler.t);

		}).Add(delegate() {
			SoundManager.Get.PlayClip (DoorOpeningSound, false);

			doorCamera.enabled = false;
		});

	}

	// Update is called once per frame
	void DoorStatusCheck () {

		this.tt ().Loop (t => {

			if(GameContext.Get.EnergyBlocksDestroyed >= EnergyBlocksToOpen){
				OpenDoorRoutine();
				t.EndLoop();
			}

		});

	}
}
