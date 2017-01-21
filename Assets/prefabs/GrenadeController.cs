using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class GrenadeController : MonoBehaviour {

	public float pullRadius = 2;
	public float pullForce = 1;
	public GameObject grenadeBody;
	public GameObject explosionSphere;

	// Use this for initialization
	void Start () {

		Destroy (explosionSphere.GetComponent<Rigidbody>());

		ActivateGrenade ();

	}

	public void ChangeColorRoutine(){
	
		Renderer grenadeRenderer = grenadeBody.GetComponent<Renderer> ();

		Color defaultColor = grenadeRenderer.material.color;

		this.tt().Add(0.2f, handler => {

			grenadeRenderer.material.color = Color.red;	

		}).Add(0.2f, handler => {

			grenadeRenderer.material.color = defaultColor;	

		}).Repeat();

	}

	public void ImplosionSphereRoutine(){
	
		explosionSphere.SetActive (true);

		var sphereRenderer = explosionSphere.GetComponent<Renderer> ();

		var currentColor = sphereRenderer.material.color;

		this.tt ().Loop (2f, t=>{

			//
			// change sphere color
			//

			explosionSphere.GetComponent<Renderer> ().material.color =
				Color.Lerp(currentColor, new Color (0f, 0f, 0f), t.t);

		});

		var currentSize = explosionSphere.transform.localScale;

		this.tt ().Loop (2f, t=>{

			//
			// change sphere size
			//

			explosionSphere.transform.localScale = Vector3.Lerp(currentSize, Vector3.zero, t.t);

		});

	}

	public void ActivateGrenade(){

		this.tt ().Add(2f).Add (ttHandler => {

			ChangeColorRoutine();

		}).Add(3, t=>{

			ImplosionSphereRoutine();

		}).Loop(2f, handler => {
		
			foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius)) {

				// calculate direction from target to me
				Vector3 forceDirection = transform.position - collider.transform.position;

				// apply force on target towards me
				var rigidBody = collider.GetComponent<Rigidbody>();

				if (rigidBody) {

					rigidBody.AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
				}
			}

		});

	}

}
