using UnityEngine;
using System.Collections;

public class FlowerController : MonoBehaviour {

	public GameObject petalsPivot;

	public float speed = 3;

	// Use this for initialization
	void Start () {
	
		MoveRoutine ();

	}

	void MoveRoutine(){

		this.ttLoop (delegate(ttHandler handlero) {

			petalsPivot.transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * speed ));

		});

	}
}
