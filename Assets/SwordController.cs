using UnityEngine;
using System.Collections;
using matnesis.TeaTime;

public class SwordController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		SwingRoutine ();

	}
	
	// Update is called once per frame
	void SwingRoutine (){
	
		this.tt().Loop (0.5f, delegate(ttHandler handler){

			transform.localPosition = Vector3.Slerp(transform.localPosition, transform.localPosition + new Vector3(1, 0, 1), handler.t);

		});

		//torta
	}
}
