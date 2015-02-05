using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

	public GameObject playerBody;

	public float speed = 0;

	public Vector3 lookDirection = Vector3.zero;

	public float jumpSpeed = 8.0F;

	public float gravity = 20.0F;

	public Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
	
		MoveRoutine ();

	}
	
	void MoveRoutine(){

		float xAxis = 0;

		float yAxis = 0;

		CharacterController controller = GetComponent<CharacterController>();

		this.ttLoop (delegate(ttHandler handler){

			xAxis = Input.GetAxis("Horizontal");
			
			yAxis = Input.GetAxis("Vertical");

			if (controller.isGrounded) {

				moveDirection = new Vector3(xAxis, 0, yAxis);

				playerBody.transform.LookAt( transform.position + moveDirection, Vector3.up);

				moveDirection = Camera.main.transform.TransformDirection(moveDirection);

				moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);

				moveDirection *= speed;

				if (Input.GetButton("Jump")){
					moveDirection.y = jumpSpeed;
				}

			}

			moveDirection.y -= gravity * Time.deltaTime;

			controller.Move(moveDirection * Time.deltaTime);
		});

	}
}
