using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class PlatformController : MonoBehaviour {

	public Transform FinalPosition;
	public float MovingTime = 3f;

	// Use this for initialization
	void Start () {

		MoveRoutine ();

	}

	// Update is called once per frame
	void MoveRoutine () {

		Vector3 startPos = transform.position;

		this.tt ().Loop (MovingTime, handler => {

			transform.position = Vector3.Lerp (startPos, FinalPosition.position, handler.t);

		}).Loop (MovingTime, handler => {

			transform.position = Vector3.Lerp (FinalPosition.position, startPos, handler.t);

		}).Repeat ();

	}
}
