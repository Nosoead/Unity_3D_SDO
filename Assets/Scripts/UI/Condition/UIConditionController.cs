using UnityEngine;

//UI내용 담고 있습니다. UIManager에 등록되어 참조항목들을 PlayerConditionController에게 보여줍니다.
public class UIConditionController : MonoBehaviour
{
    public HealthConditionUI healthConditionUI;
    public HungerConditionUI hungerConditionUI;
    public StaminaConditionUI staminaConditionUI;

    private void Awake()
    {
        healthConditionUI = GetComponentInChildren<HealthConditionUI>();
        hungerConditionUI = GetComponentInChildren<HungerConditionUI>();
        staminaConditionUI = GetComponentInChildren<StaminaConditionUI>();
    }

}
