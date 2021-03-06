﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;


public class EnergyBlockController : MonoBehaviour {

	public ParticleSystem particles;

	public float speed = 3;

	// Use this for initialization
	void Start () {

		MoveRoutine ();

	}

	ParticleSystem someParticleSystem;

	public void PrepareToDestruction(){

		particles.Stop();

		this.tt ("DestroyRoutine").Add (1f, t=>{
			
			Destroy(gameObject);

			GameContext.Get.EnergyBlocksDestroyed++;

		}).Immutable();
	}

	public void MoveRoutine(){

		var currentPosition = transform.position;

		this.tt("MoveRoutine").Loop (5f, delegate(ttHandler t) {

			transform.position = Vector3.Lerp(currentPosition, currentPosition + Vector3.up, t.t);

		}).Loop (5f, delegate(ttHandler t) {

			transform.position = Vector3.Lerp(currentPosition + Vector3.up, currentPosition, t.t);

		}).Repeat();

	}

	public void OnDisable(){
		this.tt ("MoveRoutine").Stop ();
	}
}