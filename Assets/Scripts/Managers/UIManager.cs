using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public UIConditionController conditionController;
    public GameObject Inventory;

    private void Start()
    {
        Inventory = GameObject.Find("CanVas_InventoryUI");
    }
}

