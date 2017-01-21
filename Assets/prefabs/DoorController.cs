using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class DoorController : MonoBehaviour {

	public Transform OpenPosition;
	public bool OpenDoor = false;
	public float OpenTime = 3f;


	// Use this for initialization
	void Start () {

		DoorStatusCheck ();

	}

	// Update is called once per frame
	void OpenDoorRoutine () {

		Vector3 startPos = transform.position;

		this.tt ().Loop (OpenTime, handler => {

			transform.position = Vector3.Lerp(startPos, OpenPosition.position, handler.t);

		});

	}

	// Update is called once per frame
	void DoorStatusCheck () {

		this.tt ().Loop (t => {

			if (OpenDoor) {
				OpenDoorRoutine();
			}

		});

	}
}
