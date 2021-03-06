﻿using UnityEngine;
using System.Collections;
using DG.Tweening;
using matnesis.TeaTime;
using Exploder.Utils;

public class PlayerController : MonoBehaviour
{

    public GameObject playerBody;

	public AudioClip JumpSound;

	public AudioClip ThrowGrenadeSound;

    public float speed = 0;

    public Vector3 lookDirection = Vector3.zero;

    public float jumpSpeed = 8.0F;

    public float jumpHoldTime = 0.25f;

    public float gravity = 20.0F;

    public Vector3 groundDirection = Vector3.zero;

    public Vector3 moveDirection = Vector3.zero;

    private ValueWrapper<bool> jumpBoolWrapper = new ValueWrapper<bool>(false);

	public GameObject grenadePrefab;

	public float grenadeThrowforce = 100f;

	public Transform throwPivot;

	float xAxis = 0;

	float yAxis = 0;

	public CharacterController controller;

    // Use this for initialization
    void Start()
    {
        MoveRoutine();

		ThrowGrenadeRoutine();
    }

	void ThrowGrenadeRoutine(){

		this.tt ().Loop (t => {

			if(Input.GetButtonDown("Fire1")){

				//
				// instantiate the granade
				//

				SoundManager.Get.PlayClip (ThrowGrenadeSound, false);

				GameObject grenade = Instantiate (grenadePrefab, throwPivot.position, Quaternion.identity);

				Vector3 throwDirection = -throwPivot.forward + new Vector3(0f, 1f, 0f);

				grenade.GetComponent<Rigidbody>().AddForce((throwDirection * grenadeThrowforce));

			}

		}).Immutable();

	}

	void Update(){

		xAxis = Input.GetAxis("Horizontal");

		yAxis = Input.GetAxis("Vertical");

		#region horizontal movement

		groundDirection = new Vector3(xAxis, 0, yAxis);

		playerBody.transform.LookAt(transform.position + groundDirection, Vector3.up);

		groundDirection = Camera.main.transform.TransformDirection(groundDirection);

		groundDirection = new Vector3(groundDirection.x, 0, groundDirection.z);

		groundDirection *= speed;

		#endregion

		#region Vertical movement

		bool jump = Input.GetButton("Jump");

		jumpBoolWrapper.Value = jump;

		if (controller.isGrounded)
		{
			moveDirection.y = 0f;

			if (jump)
			{
				SoundManager.Get.PlayClip (JumpSound, false);

				moveDirection.y = jumpSpeed;

				this.tt("buttonKeptPressedRoutine").Loop(jumpHoldTime, delegate (ttHandler jumpHandler)
					{
						if (jumpBoolWrapper.Value)
						{
							moveDirection.y += Mathf.Lerp(jumpSpeed, 0f, jumpHandler.t);
						}
						else
						{
							jumpHandler.EndLoop();
						}

					}).Immutable();
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;

		#endregion

		moveDirection = new Vector3(groundDirection.x, moveDirection.y, groundDirection.z);

		controller.Move(moveDirection * Time.deltaTime);

	}

    void MoveRoutine()
    {

        this.tt().Loop(t => {

            
        });

    }

	public void Kill(){
	
		this.tt ("killPlayer").Add (0.15f, delegate() {

			Camera.main.transform.parent = null;

			GameContext.Get.tt("ShowMenu").Add (1f, delegate() {
				GameContext.Get.DieMenuPanel.SetActive(true);
			}).Immutable();

			ExploderSingleton.ExploderInstance.ExplodeObject (gameObject);

		});

	}
}
