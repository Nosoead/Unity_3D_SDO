//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//리펙토링하다가 실패했습니다. 나중에 공부용으로 남겼습니다.


//public class InventoryButtonHandler : MonoBehaviour
//{
//    private UIInventoryController inventoryController;
//    private InventoryDisplay inventoryDisplay;
//    private PlayerConditionController conditionController;

//    int selectedItemIndex = 0;

//    private void Awake()
//    {
//        inventoryController = GetComponent<UIInventoryController>();
//        conditionController = CharacterManager.Instance.Player.conditionController;
//    }
//    public void OnUseButton()
//    {
//        if (inventoryController.selectedItem.itemType == ItemType.Consumable)
//        {
//            for (int i = 0; i < inventoryController.selectedItem.consumables.Length; i++)
//            {
//                switch (inventoryController.selectedItem.consumables[i].type)
//                {
//                    case ConsumableType.Health:
//                        conditionController.healthHandler.ApplyExternalEffect(selectedItem.consumables[i].value);
//                        break;
//                    case ConsumableType.Hunger:
//                        conditionController.hungerHandler.ApplyExternalEffect(selectedItem.consumables[i].value);
//                        break;
//                    case ConsumableType.Speed:

//                        break;
//                    case ConsumableType.Double:

//                        break;
//                    case ConsumableType.DevilFruit:

//                        break;
//                }
//            }
//            RemoveSelectedItem();
//        }
//    }

//    public void OnDropButton()
//    {
//        inventoryController.ThrowItem(inventoryController.selectedItem);
//        RemoveSelectedItem();
//    }

//    private void RemoveSelectedItem()
//    {
//        inventoryController.slots[selectedItemIndex].quantity--;

//        if (inventoryController.slots[selectedItemIndex].quantity <= 0)
//        {
//            inventoryController.selectedItem = null;
//            inventoryController.slots[selectedItemIndex].item = null;
//            selectedItemIndex = -1;
//            inventoryDisplay.ClearSelectedItemWindow();
//        }

//        UpdateUI();
//    }

//    public void OnEquipButton()
//    {
//        if (slots[curEquipIndex].equipped)
//        {
//            UnEquip(curEquipIndex);
//        }

//        slots[selectedItemIndex].equipped = true;
//        curEquipIndex = selectedItemIndex;
//        CharacterManager.Instance.Player.equip.EquipNew(inventoryController.selectedItem);
//        UpdateUI();

//        SelectItem(selectedItemIndex);
//    }

//    private void UnEquip(int index)
//    {
//        slots[index].equipped = false;
//        CharacterManager.Instance.Player.equip.UnEquip();
//        UpdateUI();

//        if (selectedItemIndex == index)
//        {
//            SelectItem(selectedItemIndex);
//        }
//    }

//    public void OnUnEquipButton()
//    {
//        UnEquip(selectedItemIndex);
//    }
//}
