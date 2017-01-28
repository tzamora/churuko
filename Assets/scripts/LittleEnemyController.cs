using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class LittleEnemyController : MonoBehaviour {

    public GameObject playerBody;

    public float speed = 0;

    public Vector3 lookDirection = Vector3.zero;

    public float jumpSpeed = 8.0F;

    public float jumpHoldTime = 0.25f;

    public float gravity = 20.0F;

    public Vector3 groundDirection = Vector3.zero;

    public Vector3 moveDirection = Vector3.zero;

    private ValueWrapper<bool> jumpBoolWrapper = new ValueWrapper<bool>(false);

    public CharacterController controller;

    bool jump = false;

    // Use this for initialization
    void Start()
    {
        MoveRoutine();

        AIJumpRoutine();

        // AISearchRoutine();

        // AIAttackRoutine();
    }

    void MoveRoutine()
    {

        Vector3 playerPosition = Vector3.zero;

        float xAxis = 0;

        float yAxis = 0;

        this.tt().Loop(t => {

            playerPosition = GameManager.Get.mainPlayer.transform.position; // possible improvement

            Vector3 heading = playerPosition - transform.position;

            xAxis = 1;//new Vector3(0f,0f,0f);

            yAxis = 1;// new Vector3(0f, 1f, 0f);

            #region Horizontal movement

            groundDirection = new Vector3(xAxis, 0, yAxis);

            playerBody.transform.LookAt(transform.position + groundDirection, Vector3.up);

            groundDirection = Camera.main.transform.TransformDirection(groundDirection);

            groundDirection = new Vector3(groundDirection.x, 0, groundDirection.z);

            groundDirection *= speed;

            #endregion

            #region Vertical movement

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

            //print("==> " + moveDirection);
        });

    }

    void AIJumpRoutine() {

        this.tt("AIJumpRoutine").Add(t =>
        {
            jump = true;

        })
        .Add(t =>
        {
            jump = false;

        }).Add(1f).Repeat();

    }
}
