using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderController : MonoBehaviour {

    public event Action<Collider> TriggerEnter;

    public void OnTriggerEnter(Collider other) {
        TriggerEnter(other);
    }

	public event Action<Collider> TriggerExit;

	public void OnTriggerExit(Collider other) {
		TriggerExit(other);
	}
}
