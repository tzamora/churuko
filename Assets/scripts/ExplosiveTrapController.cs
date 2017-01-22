using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class ExplosiveTrapController : MonoBehaviour
{
	public GameObject pipeBody;

	public float pullRadius = 2;
	public float pullForce = 1;
	public GameObject explosionSphere;

	private Vector3 sphereDefaultSize;

	// Use this for initialization
	void Start ()
	{
		ActivateGrenade ();

		sphereDefaultSize = new Vector3(7f, 7f, 7f);

		RotationRoutine ();
	}

	void RotationRoutine ()
	{
		this.tt	().Loop (t => {

			pipeBody.transform.Rotate (new Vector3 (0f, 100f * Time.deltaTime, 0f));

		});
	}

	public void ExplosionSphereRoutine(){

		var currentSize = explosionSphere.transform.localScale;

		var sphereRenderer = explosionSphere.GetComponent<Renderer> ();

		var currentColor = sphereRenderer.material.color;

		this.tt ().Loop (0.3f, t=>{

			//
			// change sphere size
			//

			sphereRenderer.material.color = Color.Lerp(currentColor, new Color(0f, 0f, 0f, 0f), t.t);

			explosionSphere.transform.localScale = Vector3.Lerp(Vector3.zero, sphereDefaultSize, t.t);

		}).Add(delegate() {
			explosionSphere.transform.localScale = Vector3.zero;
		}).Immutable();

	}

	public void ActivateGrenade(){

		this.tt ().Add(2f, delegate() {

			ExplosionSphereRoutine();

		}).Add(t=>{

			foreach (Collider col in Physics.OverlapSphere(transform.position, pullRadius)) {

				var player = col.GetComponent<PlayerController>();

				if(player){

					// calculate direction from target to me
					Vector3 forceDirection = player.transform.position - transform.position;

					// apply force on target towards me
					var impactReceiver = player.GetComponent<ImpactReceiver>();

					if (impactReceiver) {

						impactReceiver.AddImpact(forceDirection.normalized, pullForce);
						//rigidBody.AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
					}

					player.Kill();
				}
			}

		}).Repeat().Immutable();

	}
}