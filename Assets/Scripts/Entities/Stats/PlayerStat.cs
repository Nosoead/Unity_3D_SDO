using UnityEngine;


//플레이어와 관련된 스탯을 모아놨습니다.
//하지만 음? LOOK에는 왜 따로 넣어놨지? 라고 할 수 있습니다.
//3인칭 하려다 망해서 거기에 있습니다. 1시전까지 계속 시도는 해보려고 합니다.
public class PlayerStat : MonoBehaviour
{
    [Header("Movement")]
    public float forwardSpeed = 3.0f;
    public float forwardRunSpeed = 7.0f;
    public float backwardSpeed = 2.0f;
    public float rotateSpeed = 2.0f;
    public float RunningStamina = -5f;

    [Header("Jump")]
    public float jumpPower = 3.0f;
    public LayerMask groundLayerMask;

    [Header("Conditions")]
    [SerializeField] private float startHealth;
    [SerializeField] private float startHunger;
    [SerializeField] private float startStamina;

    public float StartHealth { get { return startHealth; } }
    public float StartHunger { get { return startHunger; } }
    public float StartStamina { get { return startStamina; } }
}
