using UnityEngine;


//��� UI�� ��� �ֽ��ϴ�. �� �ΰ��ۿ� ��� �ΰ��� �ֽ��ϴ�.
//Inventory�� ��� GameObject�� �޴µ� �̷� �κ��� �������� ��� ����
//�÷������δ� ��� ������ ������ �н��غ����� �մϴ�.
public class UIManager : Singleton<UIManager>
{
    public UIConditionController conditionController;
    public GameObject Inventory;

    private void Awake()
    {
        Inventory = GameObject.Find("CanVas_InventoryUI");
    }
}

