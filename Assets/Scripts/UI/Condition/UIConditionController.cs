using UnityEngine;

//UI���� ��� �ֽ��ϴ�. UIManager�� ��ϵǾ� �����׸���� PlayerConditionController���� �����ݴϴ�.
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
