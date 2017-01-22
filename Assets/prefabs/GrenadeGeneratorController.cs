using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class GrenadeGeneratorController : MonoBehaviour {

	public GameObject grenadePrefab;
	GameObject Grenade1;
	GameObject Grenade2;
	GameObject Grenade3;

	// Use this for initialization
	void Start () {

		GenerateGrenades ();

	}
	
	// Update is called once per frame
	void GenerateGrenades () {

		this.tt ().Add (3f,()=> { 
			GameObject Grenade1 = Instantiate(grenadePrefab.gameObject, transform.position, Quaternion.identity);
			GameObject Grenade2 = Instantiate(grenadePrefab.gameObject, transform.position, Quaternion.identity);
			GameObject Grenade3 = Instantiate(grenadePrefab.gameObject, transform.position, Quaternion.identity);
		}).Repeat ();
			
	}
}
