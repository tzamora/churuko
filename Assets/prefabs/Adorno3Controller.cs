using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class Adorno3Controller : MonoBehaviour {

	public Transform FinalPosition;
	public Transform InitialPosition;
	public float MovingTime = 3f;

	// Use this for initialization
	void Start () {

		MoveLightsRoutine ();

	}

	void MoveLightsRoutine(){

		Vector3 startPos = transform.position;

		this.tt ().Loop (MovingTime, handler => {
			transform.position = Vector3.Lerp (startPos, FinalPosition.position, handler.t);

		}).Add(1f).Loop (MovingTime, handler => {
			
			transform.position = Vector3.Lerp (InitialPosition.position, FinalPosition.position, handler.t);

		}).Add(1f).Repeat ();

	}
}
