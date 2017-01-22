using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class Adorno1Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {

		MoveMagnetRoutine ();

	}
	
	void MoveMagnetRoutine(){

		this.tt().Loop (delegate(ttHandler rootHandler){

			//gem.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, Color.white, handler.t);

			transform.Rotate(new Vector3(0f, 100f * Time.deltaTime, 0f));

			//transform.Rotate(new Vector3(0f, 0f, 100f * Time.deltaTime));

		});

	}
}
