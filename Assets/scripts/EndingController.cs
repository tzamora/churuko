using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;


public class EndingController : MonoBehaviour {

	public ColliderController endingTrigger;

	// Use this for initialization
	void Start () {

		endingTrigger.TriggerEnter += (Collider collider) => {

			this.tt("MoveCamera").Loop(6f, t=>{

				//Camera.main.transform.movet

			});

		};

	}
}
