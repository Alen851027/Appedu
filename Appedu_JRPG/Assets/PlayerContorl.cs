using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorl : MonoBehaviour
{
    public Animator animator;
    public float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    int VelocityHash;
    int VelocutyX;
    public float LRvelocity;

    [SerializeField]
    private Camera _followCamera;

    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private float playerSpeed = 2f;
    private float jumpHeight = 1f;
    private float _gravityValue = -9.8f;

    private float PlayerSpeed = 5f;
    private CharacterController _controller;
    // Start is called before the first frame update
    void Start()
    {
        VelocutyX = Animator.StringToHash("VelocityX"); 
        VelocityHash = Animator.StringToHash("Velocity");
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimatorControl();
        Movement();
    }
    public void PlayerAnimatorControl() 
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool LeftPresserd = Input.GetKey(KeyCode.D);
        bool RightPressed = Input.GetKey(KeyCode.A);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("A");
            animator.SetInteger("Move", 1);//���k���� = 1
        }
        else if (Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("Move", 2); //�V�e =2
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("Move", 3); //��h =3
            animator.SetBool("Back", true);
            Debug.Log("SSSS");
        }
        else
        {
            animator.SetInteger("Move", 0);
            animator.SetBool("Back", false);
        }

        #region �V�e����
        {
            if (forwardPressed && velocity < 1.0f)
            {
                animator.SetBool("IsWalk", true);
                Debug.Log("WWWWW");
                velocity += Time.deltaTime * acceleration;
            }
            if (!forwardPressed && velocity > 0.0f)
            {

                velocity -= Time.deltaTime * deceleration;
            }
            if (!forwardPressed && velocity < 0.0f)
            {
                animator.SetBool("IsWalk", false);
                velocity = 0.0f;
            }
        }
        #endregion
        //-------------------------------------------------
        #region ���k����
        if (RightPressed && !LeftPresserd)
        {
            LRvelocity -= Time.deltaTime * acceleration*5;
            if (LRvelocity < -1f)
            {
                LRvelocity = -1f;
                Debug.Log("AA");
            }
        }
        else if (!RightPressed && LeftPresserd)
        {
            LRvelocity += Time.deltaTime * acceleration*5;
            if (LRvelocity > 1f)
            {
                LRvelocity = 1f;
                Debug.Log("DD");
            }
        }
        else if (!RightPressed && !LeftPresserd && LRvelocity < -0.1f)
        {
            LRvelocity += Time.deltaTime * acceleration*3;
            if (LRvelocity > -0.1f)
            {
                LRvelocity = 0f;
            }
        }
        else if (!RightPressed && !LeftPresserd && LRvelocity > 0.1f)
        {
            LRvelocity -= Time.deltaTime * acceleration*3;
            if (LRvelocity < 0.1f)
            {
                LRvelocity = 0f;
            }
        }
        //else
        //{
        //    LRvelocity = 0f;
        //}
        #endregion
        animator.SetFloat(VelocutyX, LRvelocity);
        animator.SetFloat(VelocityHash, velocity);
    }

    public void Movement() 
    {
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0,_followCamera.transform.eulerAngles.y,0)* new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;
        _controller.Move(movementDirection * PlayerSpeed * Time.deltaTime);
        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection,Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation,desiredRotation,10f*Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && _groundedPlayer)
        {
            _playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * _gravityValue);
        }
        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
}
