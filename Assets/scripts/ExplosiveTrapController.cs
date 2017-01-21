using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class ExplosiveTrapController : MonoBehaviour {

	public GameObject pipeBody;

	// Use this for initialization
	void Start () {

		RotationRoutine ();

		SpawnWaveRoutine ();

	}

	void RotationRoutine()
		{
			this.tt	().Loop (t=>{

				pipeBody.transform.Rotate(new Vector3(0f, 100f * Time.deltaTime, 0f));

			});
		}

		void SpawnWaveRoutine (){

		}
	}