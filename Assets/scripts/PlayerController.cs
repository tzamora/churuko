using UnityEngine;
using System.Collections;
using DG.Tweening;
using matnesis.TeaTime;

public class PlayerController : MonoBehaviour
{

    public GameObject playerBody;

    public float speed = 0;

    public Vector3 lookDirection = Vector3.zero;

    public float jumpSpeed = 8.0F;

    public float gravity = 20.0F;

    public Vector3 groundDirection = Vector3.zero;

    //public Vector3 moveDirection = Vector3.zero;

    private ValueWrapper<bool> jumpBoolWrapper = new ValueWrapper<bool>(false);

    public ValueWrapper<Vector3> moveDirection = new ValueWrapper<Vector3>(Vector3.zero);

    // Use this for initialization
    void Start()
    {

        MoveRoutine();

    }

    void MoveRoutine()
    {

        float xAxis = 0;

        float yAxis = 0;

        CharacterController controller = GetComponent<CharacterController>();

        this.tt().Loop(delegate (ttHandler handler) {

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
                moveDirection.Value = new Vector3(moveDirection.Value.x, 0f, moveDirection.Value.z);

                if (jump)
                {
                    //moveDirection.y = jumpSpeed;

                    print("llamando al mae");
                    this.tt("buttonKeptPressedRoutine").Loop(1f, delegate (ttHandler jumpHandler)
                    {

                        if (jumpBoolWrapper.Value)
                        {
                            float newY = moveDirection.Value.y + Mathf.Lerp(jumpSpeed, 0f, jumpHandler.t);

                            moveDirection.Value += new Vector3(moveDirection.Value.x, newY, moveDirection.Value.z);

                            

                            print("t == " + jumpHandler.t);
                            //print("movedirection.y #$%" + moveDirection.y);

                        }
                        else
                        {
                            jumpHandler.EndLoop();
                            
                        }

                        print(moveDirection.Value.y + " move direction y " + jumpHandler.t);

                    }).Add(delegate() {

                        print("se salio");

                    }) ;
                }
            }

            print("aca que llego ? " + moveDirection.Value.y); 
         PORQUE ESTA MAE LLEGA DIFERENTE!
            
            //print("jump " + (jump ? "apretado":"suelto"));

            moveDirection.Value -= new Vector3(0f, gravity * Time.deltaTime, 0f);

            #endregion

            moveDirection.Value = new Vector3(groundDirection.x, moveDirection.Value.y, groundDirection.z);

            controller.Move(moveDirection.Value * Time.deltaTime);
        });

    }
}
