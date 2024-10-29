//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//리펙토링하다가 실패했습니다. 나중에 공부용으로 남겼습니다.

//public class InventoryDisplay : MonoBehaviour
//{
//    public UIInventoryController inventoryController;

//    [Header("Select Item")]
//    public TextMeshProUGUI selectedItemName;
//    public TextMeshProUGUI selectedItemDescription;
//    public TextMeshProUGUI selectedStatName;
//    public TextMeshProUGUI selectedStatValue;
//    public GameObject useButton;
//    public GameObject equipButton;
//    public GameObject unequipButton;
//    public GameObject dropButton;

//    private void Awake()
//    {
//        inventoryController = GetComponent<UIInventoryController>();
//    }

//    public void ClearSelectedItemWindow()
//    {
//        selectedItemName.text = string.Empty;
//        selectedItemDescription.text = string.Empty;
//        selectedStatName.text = string.Empty;
//        selectedStatValue.text = string.Empty;

//        useButton.SetActive(false);
//        equipButton.SetActive(false);
//        unequipButton.SetActive(false);
//        dropButton.SetActive(false);
//    }

//    public void SelectItem(int index)
//    {
//        if (inventoryController.slots[index].item == null) return;

//        inventoryController.selectedItem = inventoryController.slots[index].item;
//        inventoryController.selectedItemIndex = index;

//        selectedItemName.text = inventoryController.selectedItem.displayName;
//        selectedItemDescription.text = inventoryController.selectedItem.description;

//        selectedStatName.text = string.Empty;
//        selectedStatValue.text = string.Empty;

//        for (int i = 0; i < inventoryController.selectedItem.consumables.Length; i++)
//        {
//            selectedStatName.text += inventoryController.selectedItem.consumables[i].type.ToString() + "\n";
//            selectedStatValue.text += inventoryController.selectedItem.consumables[i].value.ToString() + "\n";
//        }

//        useButton.SetActive(inventoryController.selectedItem.itemType == ItemType.Consumable);
//        equipButton.SetActive(inventoryController.selectedItem.itemType == ItemType.Equipable && !inventoryController.slots[index].equipped);
//        unequipButton.SetActive(inventoryController.selectedItem.itemType == ItemType.Equipable && inventoryController.slots[index].equipped);
//        dropButton.SetActive(true);
//    }
//}
