using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int locoState = Animator.StringToHash("Base Layer.Locomotion");
    static int WalkBack = Animator.StringToHash("Base Layer.WalkBack");
    static int jumpState = Animator.StringToHash("Base Layer.Jump");
    static int runState = Animator.StringToHash("Base Layer.RUN00_F");

    public float animSpeed = 1.5f;

    private Animator anim;
    private InputHandler inputHandler;
    private AnimatorStateInfo currentBaseState;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        inputHandler = GetComponent<InputHandler>();
    }

    private void OnEnable()
    {
        inputHandler.OnMoveEvent += OnWalkAnim;
        inputHandler.OnVelocityUpEvent += OnRunAnim;
        inputHandler.OnJumpEvent += OnJumpAnim;
    }

    private void OnDisable()
    {
        inputHandler.OnMoveEvent -= OnWalkAnim;
        inputHandler.OnVelocityUpEvent -= OnRunAnim;
        inputHandler.OnJumpEvent -= OnJumpAnim;
    }

    private void FixedUpdate()
    {
        anim.speed = animSpeed;
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
    }

    private void OnWalkAnim(Vector2 value)
    {
        if (value.y > 0)
        {
            anim.SetBool("isLocomotion", true);
        }
        else if (value.y<0)
        {
            anim.SetBool("isWalkBack", true);
        }
        else
        {
            anim.SetBool("isLocomotion", false);
            anim.SetBool("isWalkBack", false);
        }
    }

    private void OnRunAnim(bool isRun)
    {
        if (isRun)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    private void OnJumpAnim(bool isJump)
    {
        if (isJump)
        {
            anim.SetBool("isJump", true);
        }
        else
        {
            anim.SetBool("isJump", false);
        }
    }
}
