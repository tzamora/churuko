using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class PipeController : MonoBehaviour {

	public Transform InitialPosition;

	public Transform FinalPosition;

	public float MovingTime = 1f;

	// Use this for initialization
	void Start () {
		
		MoveLightsRoutine ();

	}
	
	// Update is called once per frame
	void MoveLightsRoutine(){

		Vector3 startPos = InitialPosition.position;

		this.tt ().Loop (MovingTime, handler => {
			transform.position = Vector3.Lerp (startPos, FinalPosition.position, handler.t);

		}).Add(0f).Loop (MovingTime, handler => {

			transform.position = Vector3.Lerp (InitialPosition.position, FinalPosition.position, handler.t);

		}).Add(0f).Repeat ();

	}
}
