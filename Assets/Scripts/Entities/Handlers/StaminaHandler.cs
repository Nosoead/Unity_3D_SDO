using UnityEngine;
using UnityEngine.Events;

//�ｺ�� �����մϴ�. ���� �߻�ȭ�� �������̽��� �����Ϸ��ٰ� �Ϸ� �� ������ �׳� �������ϴ�.
public class StaminaHandler : MonoBehaviour
{
    [HideInInspector]
    public UnityAction<float> OnStaminaChangedEvent;

    [Header("Stamina")]
    [SerializeField] private float currentValue;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    [SerializeField] private float passiveValue;
    [SerializeField] private float passiveInterval;
    [SerializeField] private float runningStaminaCost = 5f;  // �޸��� ���¹̳� �Ҹ�
    [SerializeField] private float runningInterval = 0.5f;

    private float passiveTimer;
    private float runningTimer;
    bool isRunning;

    private InputHandler inputHandler;
    private PlayerStat stat;

    public float CurrentValue
    {
        get { return currentValue; }
        set
        {
            float clampedValue = Mathf.Clamp(value, minValue, maxValue);
            if (currentValue != clampedValue)
            {
                currentValue = clampedValue;
                OnStaminaChangedEvent?.Invoke(clampedValue);
            }
        }
    }

    public float MaxValue { get { return maxValue; } }

    private void Awake()
    {
        inputHandler = GetComponentInParent<InputHandler>();
        stat = GetComponentInParent<PlayerStat>();
    }

    private void OnDisable()
    {
        inputHandler.OnVelocityUpEvent += OnRunning;
    }

    private void OnEnable()
    {
        inputHandler.OnVelocityUpEvent += OnRunning;
    }

    private void Start()
    {
        SetInitialValue(stat.StartStamina);
    }

    private void Update()
    {
        if (isRunning)
        {
            runningTimer += Time.deltaTime;
            if (runningTimer >= runningInterval)
            {
                ApplyRunningEffect();
                runningTimer = 0f;
            }
        }
        else
        {
            passiveTimer += Time.deltaTime;
            if (passiveTimer > passiveInterval)
            {
                ApplyPassiveEffect(passiveValue);
                passiveTimer = 0f;
            }
        }
    }

    private void OnRunning(bool running)
    {
        isRunning = running;
    }

    private void SetInitialValue(float StartStamina)
    {
        currentValue = StartStamina;
    }

    private void ApplyPassiveEffect(float passiveValue)
    {
        CurrentValue += passiveValue;
    }

    private void ApplyRunningEffect()
    {
        CurrentValue += stat.RunningStamina;
    }

    public void ApplyExternalEffect(float ExternalValue)
    {
        CurrentValue += ExternalValue;
    }
}
