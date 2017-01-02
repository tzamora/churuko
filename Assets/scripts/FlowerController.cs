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

		this.tt().Loop (delegate(ttHandler handlero) {

			petalsPivot.transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * speed ));

		});

	}
}
