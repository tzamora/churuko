using Exploder.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosivePropController : MonoBehaviour {

    // Use this for initialization
	void Start () {


		
	}

    public void DestroyProp() {

        ExploderSingleton.ExploderInstance.ExplodeObject(gameObject);

    }
}
