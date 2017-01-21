using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class GrenadeController : MonoBehaviour {

	public float pullRadius = 2;
	public float pullForce = 1;
	public GameObject grenadeBody;
	public GameObject explosionSphere;

	private Vector3 sphereDefaultSize;

	// Use this for initialization
	void Start () {

		Destroy (explosionSphere.GetComponent<Rigidbody>());

		ActivateGrenade ();

		sphereDefaultSize = explosionSphere.transform.localScale;

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

	public void ExplosionSphereRoutine(){

		var currentSize = explosionSphere.transform.localScale;

		var sphereRenderer = explosionSphere.GetComponent<Renderer> ();

		var currentColor = sphereRenderer.material.color;

		this.tt ().Loop (0.2f, t=>{

			//
			// change sphere size
			//

			sphereRenderer.material.color = Color.Lerp(currentColor, new Color(0f, 0f, 0f, 0f), t.t);

			explosionSphere.transform.localScale = Vector3.Lerp(Vector3.zero, sphereDefaultSize, t.t);

		}).Add(delegate() {
			Destroy(explosionSphere.gameObject);
		});

	}

	public void ActivateGrenade(){

		this.tt ().Add(2f).Add (ttHandler => {

			ChangeColorRoutine();

		}).Add(3, t=>{

			ImplosionSphereRoutine();

		}).Loop(2f, handler => {
		
			foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius)) {

				var energyBlock = collider.GetComponent<EnergyBlockController>();

				if(energyBlock){
				
					energyBlock.enabled = false;

					// calculate direction from target to me
					Vector3 forceDirection = transform.position - collider.transform.position;

					// apply force on target towards me
					var rigidBody = collider.GetComponent<Rigidbody>();

					if (rigidBody) {

						rigidBody.isKinematic = false;

						rigidBody.AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
					}

				}
			}

		}).Add(delegate() {
			
			ExplosionSphereRoutine();

		}).Loop(0.25f, t=>{

			foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius)) {

				var energyBlock = collider.GetComponent<EnergyBlockController>();

				if(energyBlock){

					energyBlock.PrepareToDestruction();

					// calculate direction from target to me
					Vector3 forceDirection = collider.transform.position - transform.position;

					// apply force on target towards me
					var rigidBody = collider.GetComponent<Rigidbody>();

					if (rigidBody) {

						rigidBody.AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
					}	
				}
			}

		}).Add(delegate() {
			Destroy(gameObject);
		}).Immutable();

	}

}
