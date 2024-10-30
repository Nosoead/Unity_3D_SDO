using System.Collections;
using UnityEngine;


//W,S�� ���������� A,D�� �¿� ȸ���� �մϴ�.
//����� �̵��� �ӵ��� �ΰ��� �̺�Ʈ�� �����ؼ� shift�� ������ �޸��� �ӵ��� �س����ϴ�.

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody movementRigidbody;
    private InputHandler inputHandler;
    private PlayerStat stat;

    private float moveDirection = 0;
    private float moveRotate = 0;
    private bool isRunning = false;

    //�ڷ�ƾ�� ���� �ӵ��� 30�ʰ� �����ϰ� �߽��ϴ�. ���� �̼��ؼ� �����ѹ� ����ϴ�.
    private float speedMultiplier = 1f;
    private Coroutine coroutine;

    private void Awake()
    {
        movementRigidbody = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
        stat = GetComponent<PlayerStat>();
    }

    private void OnEnable()
    {
        inputHandler.OnMoveEvent += OnMovement;
        inputHandler.OnVelocityUpEvent += OnVelocityUp;
    }

    private void OnDisable()
    {
        inputHandler.OnMoveEvent -= OnMovement;
        inputHandler.OnVelocityUpEvent -= OnVelocityUp;
    }

    private void FixedUpdate()
    {
        ApplyMovement(moveDirection, speedMultiplier);
        ApplyRotate(moveRotate);
    }

    private void OnMovement(Vector2 direction)
    {
        moveDirection = direction.y;
        moveRotate = direction.x * stat.rotateSpeed;
    }

    private void OnVelocityUp(bool isPressed)
    {
        isRunning = isPressed;
    }

    private void ApplyMovement(float moveDirection, float speedMultiplier)
    {
        //TODO : if������ ���Ʒ��� �ٲ��ֱ�.
        Vector3 currentDirection = transform.forward * moveDirection;
        bool isMovingBackward = Vector3.Dot(currentDirection, transform.forward) < 0;

        float currentSpeed = isMovingBackward 
            ? stat.backwardSpeed 
            : (isRunning ? stat.forwardRunSpeed : stat.forwardSpeed);

        currentDirection = currentDirection.normalized * currentSpeed* speedMultiplier;
        currentDirection.y = movementRigidbody.velocity.y;
        movementRigidbody.velocity = currentDirection;
    }

    private void ApplyRotate(float moveRotate)
    {
        transform.Rotate(0, moveRotate, 0);
    }

    public void SpeedUp()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(SpeedUpCoroutine(30f, 1.5f));
    }

    private IEnumerator SpeedUpCoroutine(float delayTime, float speedUp)
    {
        speedMultiplier = speedUp;
        yield return new WaitForSeconds(delayTime);
        speedMultiplier = 1f;
    }
}
