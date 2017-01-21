using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour {

	public float pullRadius = 2;
	public float pullForce = 1;

	// Use this for initialization
	void Start () {
		
	}

	public void FixedUpdate() {

		print ("eston se llama demasiado");

		foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius)) {
			
			// calculate direction from target to me
			Vector3 forceDirection = transform.position - collider.transform.position;

			// apply force on target towards me
			var rigidBody = collider.GetComponent<Rigidbody>();

			if (rigidBody) {
			
				rigidBody.AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
			}
		}
	}
}
