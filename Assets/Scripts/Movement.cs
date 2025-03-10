using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ControllerType { 
    Unset = 0,
    User = 1,
    Scripted = 3
}

public class Movement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D playerRigidbody2D;
    [SerializeField]
    private bool isGround = true;
    [SerializeField]
    private Animator playerAnimator = null;
    [SerializeField]
    private int XTransformAdjust = 1;
    [SerializeField] AudioClip jumpSound;
    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    public bool IsHurt { get; set; } = false; 
    public Animator anim;
    ControllerType controllerType = ControllerType.User;
    public GameLogic gameLogic;
    public bool IsInitialized = false;
    public Rigidbody2D RigidBody;
    private bool IsMovingLeft = false;
    private bool IsMovingRight = false;
    private bool IsMovingUp = false;
    private bool IsMovingDown = false;
    public float SpeedX = 5f;
    public float SpeedXBoost = 1f;
    public float SpeedY = 5f;
    public float SpeedYBoost = 1f;
    public float JumpForce = 9.81f;
    public int MaxJump = 1;
    public int JumpCount = 1;
    public float Speed => this.RigidBody?.velocity.x ?? 0;
    public void SetControllerType(ControllerType controllerType)
    {
        gameLogic = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>();
        this.controllerType = controllerType;
    }

    private void LateUpdate()
    {
        if(playerAnimator != null)
        {
            playerAnimator.SetFloat("xVelocity", Mathf.Abs(playerRigidbody2D.velocity.x));
            playerAnimator.SetFloat("yVelocity", playerRigidbody2D.velocity.y);
            playerAnimator.SetBool("isGround", isGround);
        }
    }
    private void FixedUpdate()
    {
        if (IsInitialized == false) return;

        if (!gameLogic.GameIsActive) { 
            var pauseVelocityVector = new Vector3(0, 0, 0);
            this.RigidBody.velocity = pauseVelocityVector;
            return;
        };
        
        float moveX = SpeedX * SpeedXBoost;
        if ((!this.IsMovingLeft && !this.IsMovingRight) ||
            (this.IsMovingLeft && this.IsMovingRight)) moveX = 0f;


        if (IsMovingLeft) moveX = Math.Abs(moveX) * -1;

        if (Math.Abs(moveX) >= 1)
        {
            float tranform = (IsMovingLeft ? -1 : 1) * XTransformAdjust;
            transform.localScale = new Vector3(tranform * Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        float moveY = SpeedY * SpeedYBoost;
        if ((!this.IsMovingUp && !this.IsMovingDown) ||
            (this.IsMovingUp && this.IsMovingDown)) moveY = this.RigidBody.velocity.y;


        if (IsMovingDown) moveY *= -1;

        this.RigidBody.velocity = new Vector3(moveX, moveY, 0);
    }

    public void MoveRight(bool isMoveRight) { 
        this.IsMovingRight = isMoveRight;

    }

    public void MoveLeft(bool isMovingLeft) { 
        this.IsMovingLeft = isMovingLeft;   
    }

    public void MoveUp(bool isMoveUp)
    {
        this.IsMovingUp = isMoveUp;

    }

    public void MoveDown(bool isMoveDown)
    {
        this.IsMovingDown = isMoveDown;
    }


    public void Jump() {

        if (JumpCount > 0) {

            if (jumpSound != null) SoundFXManager.instance.PlaySoundFXClip(jumpSound, gameObject.transform, .8f);
            this.RigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            JumpCount--;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGround = true;
            this.JumpCount = this.MaxJump;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGround = false;
        }
    }

    public void GetHurt(Vector2 knockbackForce)
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("isHurt");
        }

        IsHurt = true;
        RigidBody.velocity = Vector2.zero;
        RigidBody.AddForce(knockbackForce, ForceMode2D.Impulse);

        StartCoroutine(RecoverFromHurt());
    }

    private IEnumerator RecoverFromHurt()
    {
        yield return new WaitForSeconds(0.5f);
        IsHurt = false;
    }
}
