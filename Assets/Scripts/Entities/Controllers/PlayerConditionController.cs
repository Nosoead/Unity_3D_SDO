using UnityEngine;


//���Ǹ� ���� �� �� �����UI�� ��������ϸ� ����å�ӿ�Ģ�� ���ݵǴ� ���� �ƴѰ� �����߰�
//�̿� ���� �÷��̾�� �� ������ڵ鷯�� �����ϰ� ��Ʈ�ѷ��� �����͸� �������ݴϴ�.
//�ٵ� �� �̼��ؼ� ������� ü���� ���̰� �ߴµ� �� ���� �ʾҽ��ϴ�.
//�̰� �ϴٰ� ������ ���ư����ϴ�.
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
