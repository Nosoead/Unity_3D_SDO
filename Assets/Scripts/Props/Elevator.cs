using UnityEngine;


//르탄레인 세로버전 엘리베이터입니다.
public class Elevator : MonoBehaviour
{
    public float elevatorSpeed;
    public float moveDistance;
    private Vector3 position;
    private float minY;
    private float maxY;
    private float speed;
    private void Awake()
    {
        position = transform.position;
        minY = transform.position.y;
        maxY = minY + moveDistance;
    }
    private void Update()
    {
        elevatorMove();
    }

    private void elevatorMove()
    {
        if (transform.position.y <= minY)
        {
            speed = elevatorSpeed;
        }
        else if (transform.position.y >= maxY)
        {
            speed = -elevatorSpeed;
        }
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
