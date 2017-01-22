using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderController : MonoBehaviour {

    public event Action<Collider> TriggerEnter;

    void OnTriggerEnter(Collider other) {
		if(TriggerEnter!=null) TriggerEnter(other);
    }

	public event Action<Collider> TriggerExit;

	void OnTriggerExit(Collider other) {
		if(TriggerExit!=null) TriggerExit(other);
	}
}
