using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody jumpRigidbody;
    private InputHandler inputHandler;
    private PlayerStat stat;

    private int jumpCounter = 0;
    private int jumpMaxCounter = 1;
    private Coroutine coroutine;

    private void Awake()
    {
        jumpRigidbody = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
        stat = GetComponent<PlayerStat>();
    }

    private void OnEnable()
    {
        inputHandler.OnJumpEvent += OnJump;
    }

    private void OnDisable()
    {
        inputHandler.OnJumpEvent -= OnJump;
    }

    private void OnJump()
    {
        if (IsGround())
        {
            jumpRigidbody.AddForce(Vector2.up * stat.jumpPower, ForceMode.Impulse);
        }
    }

    private bool IsGround()
    {

        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward*0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward*0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right*0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right*0.2f) + (transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, stat.groundLayerMask) && jumpCounter ==0)
            {
                jumpCounter++;
                return true;
            }
            else if (jumpCounter < jumpMaxCounter)
            {
                jumpCounter++;
                return true;
            }
        }
        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, stat.groundLayerMask))
            {
                jumpCounter = 0;
            }
        }
        return false;
    }

    public void DoubleJump()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(SpeedUpCoroutine(30f, 2));
    }

    private IEnumerator SpeedUpCoroutine(float delayTime, int jumpCounter)
    {
        jumpMaxCounter = jumpCounter;
        yield return new WaitForSeconds(delayTime);
        jumpMaxCounter = 0;
    }
}
