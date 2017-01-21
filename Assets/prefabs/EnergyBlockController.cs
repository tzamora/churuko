using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;


public class EnergyBlockController : MonoBehaviour {

	public float speed = 3;

	// Use this for initialization
	void Start () {

		MoveRoutine ();

	}

	public void PrepareToDestruction(){
		
	}

	public void MoveRoutine(){

		this.tt().Loop (delegate(ttHandler handlero) {

			transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * speed ));

		});

	}
}
