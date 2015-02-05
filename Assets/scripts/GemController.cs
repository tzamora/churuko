using UnityEngine;
using System.Collections;

public class GemController : MonoBehaviour {

	public GameObject gem;

	// Use this for initialization
	void Start () {
	
		MoveGemRoutine ();

	}
	
	void MoveGemRoutine(){
		
		this.ttLoop (delegate(ttHandler rootHandler){
			
			this.ttSimpleLoop (2f, delegate(ttHandler handler) {
				
				//gem.renderer.material.color = Color.Lerp(Color.black, Color.white, handler.t);

				gem.transform.Rotate (new Vector3 (0f, 100f * Time.deltaTime, 0f));

				gem.transform.Rotate (new Vector3 (0f, 0f, 100f * Time.deltaTime));
				
			});
			
			rootHandler.WaitFor(1f);
			
		});
		
	}
}
