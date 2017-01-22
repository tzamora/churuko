using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillColliderController : MonoBehaviour {

	public ColliderController killCollider;

	// Use this for initialization
	void Start () {

		killCollider.TriggerEnter += (Collider collider) => {

			var player = collider.GetComponent<PlayerController>();

			if(player){
				
				player.Kill();
			
			}

		};

	}
}
