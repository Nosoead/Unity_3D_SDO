using UnityEngine;


public class Trap : MonoBehaviour
{
    private Vector3 firstPoint;
    private Vector3 secondPoint;
    private Vector3 position;
    private float minZ;
    public float maxZ;
    public float moveDistance;
    public float moveSpeed;
    public float speed;
    public LayerMask mask;

    void Start()
    {
        float firstx = transform.position.x - 2f;
        float y = transform.position.y + 1f;
        float z = transform.position.z;
        firstPoint = new Vector3(firstx, y, z);
        float secondx = transform.position.x - 8f;
        secondPoint = new Vector3(secondx, y, z);

        position = transform.position;
        maxZ = transform.position.z;
        minZ = maxZ + moveDistance;
    }

    private void Update()
    {
        if (IsTouched())
        {
            speed = moveSpeed;
        }
        else if (transform.position.z <= minZ)
        {
            speed = -moveSpeed * 2;
        }
        else if (transform.position.z >= maxZ)
        {
            speed = 0;
        }
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(firstPoint, Vector3.back * 10, Color.red);
        Debug.DrawRay(secondPoint, Vector3.back * 10, Color.red);
    }

    private bool IsTouched()
    {
        Ray[] rays = new Ray[2]
        {
            new Ray(firstPoint, Vector3.back),
            new Ray(secondPoint, Vector3.back)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 10f, mask))
            {
                return true;
            }
        }
        return false;
    }
}
