using UnityEngine;


//르탄레인 세로버전 엘리베이터입니다.
public class Elevator : MonoBehaviour
{
    public float elevatordirection;
    public float yRange;
    private Vector3 position;
    private float minY;
    private float maxY;
    private float direction;
    private void Awake()
    {
        position = transform.position;
        minY = transform.position.y;
        maxY = minY + yRange;
    }
    private void Update()
    {
        elevatorMove();
    }

    private void elevatorMove()
    {
        if (transform.position.y <= minY)
        {
            direction = elevatordirection;
        }
        else if (transform.position.y >= maxY)
        {
            direction = -elevatordirection;
        }
        transform.position += Vector3.up * direction * Time.deltaTime;
    }
}
