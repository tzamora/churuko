using UnityEngine;
using System.Collections;
using matnesis.TeaTime;
public class GemController : MonoBehaviour {

	public GameObject gem;

	// Use this for initialization
	void Start () {
	
		MoveGemRoutine ();

	}
	
	void MoveGemRoutine(){
		
		this.tt().Loop (3f, delegate(ttHandler rootHandler){

            //gem.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, Color.white, handler.t);

            gem.transform.Rotate(new Vector3(0f, 100f * Time.deltaTime, 0f));

            gem.transform.Rotate(new Vector3(0f, 0f, 100f * Time.deltaTime));
			
		});
		
	}
}
