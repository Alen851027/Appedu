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
    //public AnimatorStateInfo animatorinfo;
    public float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    int VelocityHash;
    int VelocutyX;
    public float LRvelocity;
    public bool isWalk;

    public Rigidbody rb;
    [SerializeField]
    private Camera _followCamera;
    
    private Vector3 _playerVelocity;
    public bool _groundedPlayer;
    private float RaycastOrigin = 0f;
    private float RaycastDistance = 0.2f;

    private float playerSpeed = 2f;
    private float jumpHeight = 1f;
    private float _gravityValue = -9.8f;
    public int isPlayAnim =-1;
    private float PlayerSpeed = 5f;
    private CharacterController _controller;
    // Start is called before the first frame update

    void Start()
    {
        //animatorinfo = animator.GetCurrentAnimatorStateInfo(0);
        VelocutyX = Animator.StringToHash("VelocityX"); 
        VelocityHash = Animator.StringToHash("Velocity");
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {

        //if (animatorinfo.IsName("Idle") || animatorinfo.IsName("Move"))
        //{

        //}
        //if (animatorinfo.IsName("SkillBtn7"))
        //{
        //    isPlayAnim = true;
        //}
        //else if (animatorinfo.IsName("Move"))
        //{
        //    isPlayAnim = false;
        //}

    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (isWalk)
        {
            
        }

        Movement();
        PlayerAnimatorControl();

    }
    public void PlayerAnimatorControl() 
    {

        isWalk = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.W))
        {
            isWalk = true;
            Debug.Log("A");
            animator.SetInteger("Move", 1);//左右移動 = 1
        }
        else
        {
            animator.SetInteger("Move", 0);
            animator.SetBool("Back", false);

        }

        #region 移動
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
        if (isPlayAnim == 0)
        {

            //if (_groundedPlayer && _playerVelocity.y < 0)
            //{
            //    _playerVelocity.y = 0f;
            //    _groundedPlayer = true;


            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
            Vector3 movementDirection = movementInput.normalized;
            _controller.Move(movementDirection * PlayerSpeed * Time.deltaTime);
            if (movementDirection != Vector3.zero)
            {
                Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, 10f * Time.deltaTime);
            }

            Debug.DrawRay(transform.position + Vector3.down * RaycastOrigin, Vector3.down * RaycastDistance, Color.blue);
            _groundedPlayer = Physics.Raycast(transform.position + Vector3.down * RaycastOrigin, Vector3.down, RaycastDistance, 1);
            if (_groundedPlayer == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))//空白鍵跳躍
                {
                    _playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * _gravityValue);
                    Debug.Log("空白建");
                    animator.SetBool("IsJump",true);
                    PlayerAnimtor("Base Layer", "Jump");
                }
                else
                {
                    animator.SetBool("IsJump", false);

                    _playerVelocity.y -= -_gravityValue*5 * Time.deltaTime;
                    if (_playerVelocity.y < 0)
                    {
                        _playerVelocity.y = 0;
                    }
                    //GetComponent<Collider>().material = TheFriction[0];
                    // rb.isKinematic = false;
                }
            }
            

            _controller.Move(_playerVelocity * Time.deltaTime);
            //if (Input.GetButton("Jump") )
            //{
            //    if (_groundedPlayer)
            //    {
            //        _playerVelocity.y -= _gravityValue * Time.deltaTime;
                    
                    
            //        animator.Play("Jump");
            //    }
            //    _playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * _gravityValue);
            //    _groundedPlayer = false;
            //}
        }

    }
    void PlayerAnimtor(string AnimLayerName, string AnimStateName)   //撥放動畫
    {
        if (animator != null)
        {
            animator.Play($"{AnimLayerName}.{AnimStateName}");
        }
    }
    void PlayerJump()  //落地偵測    
    {
      
    }



}
