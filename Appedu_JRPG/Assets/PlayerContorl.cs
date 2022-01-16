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
    // Start is called before the first frame update
    void Start()
    {
        VelocutyX = Animator.StringToHash("VelocityX"); 
        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimatorControl();
    }
    public void PlayerAnimatorControl() 
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool LeftPresserd = Input.GetKey(KeyCode.D);
        bool RightPressed = Input.GetKey(KeyCode.A);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("A");
            animator.SetInteger("Move", 1);//左右移動 = 1
        }
        else if (Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("Move", 2); //向前 =2
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("Move", 3); //後退 =3
            animator.SetBool("Back", true);
            Debug.Log("SSSS");
        }
        else
        {
            animator.SetInteger("Move", 0);
            animator.SetBool("Back", false);
        }

        #region 向前移動
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
        #region 左右移動
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
}
