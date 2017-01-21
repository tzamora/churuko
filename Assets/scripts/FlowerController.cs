using UnityEngine;
using System.Collections;
using matnesis.TeaTime;

public class FlowerController : MonoBehaviour {

	public GameObject petalsPivot;

	public float speed = 3;

	// Use this for initialization
	void Start () {
	
		MoveRoutine ();

	}

	void MoveRoutine(){

		this.tt().Loop (0.5f, delegate(ttHandler handlero) {

			petalsPivot.transform.Translate(Vector3.up * speed);

		}).Loop (0.5f, delegate(ttHandler handlero) {

			petalsPivot.transform.Translate(Vector3.down * speed);

		}).Repeat();

	}
}
