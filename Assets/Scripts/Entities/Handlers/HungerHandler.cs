using UnityEngine;
using UnityEngine.Events;

public class HungerHandler : MonoBehaviour
{
    [HideInInspector]
    public UnityAction<float> OnHungerChangedEvent;

    [Header("Hunger")]
    [SerializeField] private float currentValue;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    [SerializeField] private float passiveValue;
    [SerializeField] private float passiveTimer;
    [SerializeField] private float passiveInterval;

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
                OnHungerChangedEvent?.Invoke(clampedValue);
            }
        }
    }

    public float MaxValue { get { return maxValue; } }

    private void Awake()
    {
        stat = GetComponentInParent<PlayerStat>();
    }

    private void Start()
    {
        SetInitialValue(stat.StartHealth);
    }

    private void Update()
    {
        passiveTimer += Time.deltaTime;

        if (passiveTimer > passiveInterval)
        {
            ApplyPassiveEffect(passiveValue);
            passiveTimer = 0f;
        }
    }

    private void SetInitialValue(float StartHealth)
    {
        currentValue = StartHealth;
    }

    private void ApplyPassiveEffect(float passiveValue)
    {
        CurrentValue += passiveValue;
    }

    public void ApplyExternalEffect(float ExternalValue)
    {
        CurrentValue += ExternalValue;
    }
}
