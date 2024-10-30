using UnityEngine;


//강의를 보고 왜 각 컨디션UI가 연산까지하면 단일책임원칙이 위반되는 것이 아닌가 생각했고
//이에 따라 플레이어에서 각 컨디션핸들러가 연산하고 컨트롤러는 데이터만 제어해줍니다.
//근데 좀 미숙해서 배고프면 체력이 깍이게 했는데 좀 쉽지 않았습니다.
//이거 하다가 월요일 날아갔습니다.
public class PlayerConditionController : MonoBehaviour
{
    public HealthHandler healthHandler;
    public HungerHandler hungerHandler;
    public StaminaHandler staminaHandler;
    [SerializeField] private float hungryDamage;
    private void Awake()
    {
        healthHandler = GetComponentInChildren<HealthHandler>();
        hungerHandler = GetComponentInChildren<HungerHandler>();
        staminaHandler = GetComponentInChildren<StaminaHandler>();
    }

    private void Update()
    {
        if (hungerHandler.CurrentValue <= 0)
        {
            healthHandler.CurrentValue += hungryDamage * Time.deltaTime;
        }

        UIManager.Instance.conditionController.healthConditionUI.ApplyUI(healthHandler.CurrentValue, healthHandler.MaxValue);
        UIManager.Instance.conditionController.hungerConditionUI.ApplyUI(hungerHandler.CurrentValue, hungerHandler.MaxValue);
        UIManager.Instance.conditionController.staminaConditionUI.ApplyUI(staminaHandler.CurrentValue, staminaHandler.MaxValue);
    }

}
