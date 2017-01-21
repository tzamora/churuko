using UnityEngine;
using System.Collections;
using DG.Tweening;
using matnesis.TeaTime;

public class EnemyController : MonoBehaviour
{

    public GameObject enemyBody;

	//public CharacterController controller;

	/*
    public float jumpSpeed = 8.0F;

    public float jumpHoldTime = 0.25f;

    public float gravity = 20.0F;
	*/

	public float speed = 0;

	float xAxis = 0;

	float yAxis = 0;

	public Vector3 lookDirection = Vector3.zero;

    public Vector3 groundDirection = Vector3.zero;

    public Vector3 moveDirection = Vector3.zero;

    /*
    private ValueWrapper<bool> jumpBoolWrapper = new ValueWrapper<bool>(false);

	public GameObject grenadePrefab;

	public float grenadeThrowforce = 100f;

	public Transform throwPivot;
	*/

    // Use this for initialization
    void Start()
    {
        MoveRoutine();

		//ThrowGrenadeRoutine();
    }

	void Update(){

		/*
		xAxis = GameContext.Get.player.transform.position.x - transform.position.x;

		yAxis = GameContext.Get.player.transform.position.y - transform.position.x;

		#region horizontal movement

		groundDirection = new Vector3(xAxis, 0, yAxis);

		enemyBody.transform.LookAt(transform.position + groundDirection, Vector3.up);

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
		*/

	}

    void MoveRoutine()
    {

        this.tt().Loop(t => {

			xAxis = GameContext.Get.player.transform.position.x - transform.position.x;

			yAxis = GameContext.Get.player.transform.position.y - transform.position.x;

			#region horizontal movement

			groundDirection = new Vector3(xAxis, 0, yAxis);

			enemyBody.transform.LookAt(transform.position + groundDirection, Vector3.up);

			groundDirection = Camera.main.transform.TransformDirection(groundDirection);

			groundDirection = new Vector3(groundDirection.x, 0, groundDirection.z);

			groundDirection *= speed;

			#endregion
            
        });

    }
}
