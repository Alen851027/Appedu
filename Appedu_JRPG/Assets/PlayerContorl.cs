using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorl : MonoBehaviour
{
    public static PlayerContorl instance;
    private void Awake()
    {
        instance = this;
    }

    public Animator animator;
    public float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    int VelocityHash;
    int VelocutyX;
    public float LRvelocity;
    public bool isWalk;

    [SerializeField]
    private Camera _followCamera;

    private Vector3 _playerVelocity;
    public bool _groundedPlayer;
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
    void LateUpdate()
    {
        PlayerAnimatorControl();
        Movement();
    }
    public void PlayerAnimatorControl() 
    {
        
        isWalk = Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.W))
        {
            isWalk = true;
            Debug.Log("A");
            animator.SetInteger("Move", 1);//¥ª¥k²¾°Ê = 1
        }
        else
        {
            animator.SetInteger("Move", 0);
            animator.SetBool("Back", false);
        }

        #region ²¾°Ê
        {
            if (isWalk && velocity < 1.0f)
            {
                animator.SetBool("IsWalk", true);
                Debug.Log("WWWWW");
                velocity += Time.deltaTime * acceleration;
            }
            if (!isWalk && velocity > 0.0f)
            {

                velocity -= Time.deltaTime * deceleration;
            }
            if (!isWalk && velocity < 0.0f)
            {
                animator.SetBool("IsWalk", false);
                velocity = 0.0f;
            }
        }
        #endregion
        //-------------------------------------------------
        //
        //animator.SetFloat(VelocutyX, LRvelocity);
        animator.SetFloat(VelocityHash, velocity);
    }

    public void Movement() 
    {

        _groundedPlayer = true;
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

        if (Input.GetButton("Jump") && _groundedPlayer)
        {
            _playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * _gravityValue);
            _groundedPlayer = false;
        }
        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }
}
