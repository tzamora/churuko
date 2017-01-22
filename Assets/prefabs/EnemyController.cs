using UnityEngine;
using System.Collections;
using DG.Tweening;
using matnesis.TeaTime;
using Exploder.Utils;

public class EnemyController : MonoBehaviour
{
	public GameObject enemyBody;

	public CharacterController controller;

    public float jumpSpeed = 8.0F;

    public float jumpHoldTime = 0.25f;

    public float gravity = 20.0F;

	public float speed = 0;

	float xAxis = 0;

	float yAxis = 0;

	public Vector3 lookDirection = Vector3.zero;

    public Vector3 groundDirection = Vector3.zero;

    public Vector3 moveDirection = Vector3.zero;

    private ValueWrapper<bool> jumpBoolWrapper = new ValueWrapper<bool>(false);

	public GameObject grenadePrefab;

	public float grenadeThrowforce = 100f;

	public Transform throwPivot;


    // Use this for initialization
    void Start()
    {
		MoveRoutine();

		ThrowGrenadeRoutine ();
    }

	void ThrowGrenadeRoutine(){

		this.tt ().Add (4f, t => {

		    //
			// instantiate the granade
			//

			GameObject grenade = Instantiate (grenadePrefab, throwPivot.position, Quaternion.identity);

			//Vector3 throwDirection = -throwPivot.forward + new Vector3(0f, 1f, 0f);

			Vector3 throwDirection = enemyBody.transform.forward + Vector3.up;

			grenade.GetComponent<Rigidbody>().AddForce(throwDirection * grenadeThrowforce);


		}).Repeat().Immutable();

	}

    void MoveRoutine()
    {

        this.tt().Loop(t => {

			xAxis = 0;//GameContext.Get.player.transform.position.x;

			yAxis = 0;//GameContext.Get.player.transform.position.y;

			#region horizontal movement

			groundDirection = new Vector3(xAxis, yAxis, 0);

			enemyBody.transform.LookAt(GameContext.Get.player.transform.position, Vector3.up);

			//groundDirection = new Vector3(groundDirection.x, 0, groundDirection.z);

			groundDirection *= speed;

			#endregion
			#region Vertical movement

			bool jump = false; //Input.GetButton("Jump");

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

			//moveDirection = new Vector3(groundDirection.x, moveDirection.y, groundDirection.z);

			moveDirection = new Vector3(groundDirection.x, moveDirection.y, groundDirection.z);

			controller.Move(moveDirection * Time.deltaTime);

			transform.position = Vector3.Lerp(transform.position, GameContext.Get.player.transform.position, Time.deltaTime/2f);
        });

    }

	public void Kill(){

		this.tt ("killEnemy").Add (0.15f, delegate() {

			ExploderSingleton.ExploderInstance.ExplodeObject (gameObject);

		}).Immutable();

	}
}
