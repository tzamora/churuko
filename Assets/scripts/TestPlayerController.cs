using UnityEngine;
using System.Collections;
using DG.Tweening;
using matnesis.TeaTime;


public class TestPlayerController : MonoBehaviour {

	public GameObject part1;

	public GameObject part2;

	public GameObject part3;

	// Use this for initialization
	void Start () {
	
//		part1.transform.DOShakePosition(3f).OnComplete(delegate(){
//
//
//
//		});
	}

	void Part1Routine(){

		this.tt().Loop (delegate(ttHandler rootHandler){

			this.tt().Loop (5f, delegate(ttHandler handler) {
				
				//part1.renderer.material.color = Color.Lerp(Color.black, Color.white, Time.deltaTime);
				
				part1.transform.Rotate (new Vector3 (0f, 100f * Time.deltaTime, 0f));
				
				//part1.transform.position = Vector3.Lerp(part1.transform.position, new Vector3(part1.transform.position.x, -5f, 0f), Time.deltaTime);
				
				//part1.renderer.material.color = Color.Lerp(part1.renderer.material.color, Color.white, Time.deltaTime);
				
				//print ( "part1: " + part1.renderer.material.color );
				
			});

			rootHandler.Wait(1f);

		});

	}

	void Part2Routine(){

		this.tt("part2").Loop (3f, delegate(ttHandler handler){
			
			part2.GetComponent<Renderer>().material.color = Color.Lerp(part2.GetComponent<Renderer>().material.color, Color.white, handler.t);
			
			//part2.transform.position = Vector3.Lerp(part2.transform.position, new Vector3(part2.transform.position.x, -5f, 0f), handler.t);
			
			print ( "part2: " + part2.GetComponent<Renderer>().material.color );
			
		});

	}

	void Part3Routine(){

		this.tt("part3").Loop (3f, delegate(ttHandler handler){
			
			part3.GetComponent<Renderer>().material.color = Color.Lerp(part3.GetComponent<Renderer>().material.color, Color.white, handler.deltaTime);
			
			//part3.transform.position = Vector3.Lerp(part3.transform.position, new Vector3(part3.transform.position.x, -5f, 0f), handler.deltaTime);
			
			//print ("t: " + handler.t);
			
			//print ("loop deltaTime es: " + handler.deltaTime);
			
			//print ( "part3: " + part3.renderer.material.color );
			
		});

	}

	void OnGUI(){

		if (GUILayout.Button ("Part 1")) {
		
			Part1Routine();
		
		}

		if (GUILayout.Button ("Part 2")) {

			Part2Routine();

		}

		if (GUILayout.Button ("Part 3")) {
				
			Part3Routine();

		}

	}
}
