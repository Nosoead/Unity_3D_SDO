using UnityEngine;


//모든 UI를 담고 있습니다. 딱 두개밖에 없어서 두개만 있습니다.
//Inventory의 경우 GameObject로 받는데 이런 부분은 동적으로 어떻게 할지
//컬렉션으로는 어떻게 담을지 앞으로 학습해보려고 합니다.
public class UIManager : Singleton<UIManager>
{
    public UIConditionController conditionController;
    public GameObject Inventory;

    private void Start()
    {
        Inventory = GameObject.Find("CanVas_InventoryUI");
    }
}

