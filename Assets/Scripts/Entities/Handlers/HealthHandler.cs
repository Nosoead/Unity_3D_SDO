using UnityEngine;
using UnityEngine.Events;

//체력을 처리하는 부분입니다. 배고프면 깍이는 것인데
//만약 여기서 데미지를 받으면 데미지를 받는 클래스에서 최종 결과값만
//ApplyExternalEffect로 프로퍼티에 다가 변화를 넣어줘고
//변화를 주고 해당 값은 ConditionController가 UI한테 넘겨줍니다.
//혹여 데미지 받고 코루틴을 한다고 상상하면 (지속뎀 : 독뎀, 화상 등등)
//이벤트를 야기하고 이후 다른 UI스크립트에서 이펙트를 보여주면 되지 않을까 생각하면서
//이벤트만 ?.Invoke 했습니다.
public class HealthHandler : MonoBehaviour
{
    [HideInInspector]
    public UnityAction<float> OnHealthChangedEvent;

    [Header("Health")]
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
                OnHealthChangedEvent?.Invoke(clampedValue);
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
