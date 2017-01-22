using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class PlatformController : MonoBehaviour {

	public Transform FinalPosition;
	public float MovingTime = 3f;
	public ColliderController PlatformCollider;
	public float waittime = 0f;

	// Use this for initialization
	void Start () {

		PlatformCollider.TriggerEnter += PlatformCollider_TriggerEnter;

		PlatformCollider.TriggerExit += PlatformCollider_TriggerExit;

		MoveRoutine ();

	}

	// Update is called once per frame
	void MoveRoutine () {

		Vector3 startPos = transform.position;

		this.tt ().Loop (MovingTime, handler => {

			transform.position = Vector3.Lerp (startPos, FinalPosition.position, handler.t);

		}).Add(waittime).Loop (MovingTime, handler => {

			transform.position = Vector3.Lerp (FinalPosition.position, startPos, handler.t);

		}).Add(waittime).Repeat ();

	}

	private void PlatformCollider_TriggerEnter(Collider other){

		if (other.GetComponent<PlayerController>() != null){
			GameContext.Get.player.transform.parent = transform;
		}
			
	}

	private void PlatformCollider_TriggerExit(Collider other){

		if (other.GetComponent<PlayerController>() != null){
			GameContext.Get.player.transform.parent = null;
		}

	}
}