using TMPro;
using UnityEngine;

//강의내용 그대로에 아이템 효과만 몇몇개 172번쨰 줄 쯤에 구현했습니다.
//여기서 하루를 다 쓰고 실패해서 너무 아쉽습니다.
public class UIInventoryController : MonoBehaviour
{
    public InventoryItemSlot[] slots;

    public GameObject inventoryWindow;
    public Transform slotPanel;
    public Transform dropPosition;

    [Header("Select Item")]
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedStatName;
    public TextMeshProUGUI selectedStatValue;
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unequipButton;
    public GameObject dropButton;

    public PlayerConditionController conditionController;
    public PlayerMovement playerMovement;
    public PlayerJump playerJump;
    public ItemDataSO selectedItem;
    
    int selectedItemIndex = 0;
    int curEquipIndex;


    void Start()
    {
        conditionController = CharacterManager.Instance.Player.conditionController;
        playerMovement = CharacterManager.Instance.Player.movement;
        playerJump = CharacterManager.Instance.Player.jump;
        dropPosition = CharacterManager.Instance.Player.dropPosition;

        CharacterManager.Instance.Player.addItem += AddItem;

        slots = new InventoryItemSlot[slotPanel.childCount];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<InventoryItemSlot>();
            slots[i].index = i;
            slots[i].inventory = this;
        }

        ClearSelectedItemWindow();
    }
    
    private void ClearSelectedItemWindow()
    {
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedStatName.text = string.Empty;
        selectedStatValue.text = string.Empty;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unequipButton.SetActive(false);
        dropButton.SetActive(false);
    }
    
    private void AddItem()
    {
        ItemDataSO data = CharacterManager.Instance.Player.itemDataSO;

        if (data.canStack)
        {
            InventoryItemSlot slot = GetItemStack(data);
            if (slot != null)
            {
                slot.quantity++;
                UpdateUI();
                CharacterManager.Instance.Player.itemDataSO = null;
                return;
            }
        }

        InventoryItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot.item = data;
            emptySlot.quantity = 1;
            UpdateUI();
            CharacterManager.Instance.Player.itemDataSO = null;
            return;
        }

        ThrowItem(data);
        CharacterManager.Instance.Player.itemDataSO = null;
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }
 
    private InventoryItemSlot GetItemStack(ItemDataSO data)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == data && slots[i].quantity < data.maxStackAmount)
            {
                return slots[i];
            }
        }
        return null;
    }

    private InventoryItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                return slots[i];
            }
        }
        return null;
    }

    public void ThrowItem(ItemDataSO data)
    {
        Instantiate(data.dropPrefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360));
    }

    
    public void SelectItem(int index)
    {
        if (slots[index].item == null) return;

        selectedItem = slots[index].item;
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.displayName;
        selectedItemDescription.text = selectedItem.description;

        selectedStatName.text = string.Empty;
        selectedStatValue.text = string.Empty;

        for (int i = 0; i < selectedItem.consumables.Length; i++)
        {
            selectedStatName.text += selectedItem.consumables[i].type.ToString() + "\n";
            selectedStatValue.text += selectedItem.consumables[i].value.ToString() + "\n";
        }

        useButton.SetActive(selectedItem.itemType == ItemType.Consumable);
        equipButton.SetActive(selectedItem.itemType == ItemType.Equipable && !slots[index].equipped);
        unequipButton.SetActive(selectedItem.itemType == ItemType.Equipable && slots[index].equipped);
        dropButton.SetActive(true);
    }
    
    public void OnUseButton()
    {
        if (selectedItem.itemType == ItemType.Consumable)
        {
            for (int i = 0; i < selectedItem.consumables.Length; i++)
            {
                switch (selectedItem.consumables[i].type)
                {
                    case ConsumableType.Health:
                        conditionController.healthHandler.ApplyExternalEffect(selectedItem.consumables[i].value);
                        break;
                    case ConsumableType.Hunger:
                        conditionController.hungerHandler.ApplyExternalEffect(selectedItem.consumables[i].value);
                        break;
                    case ConsumableType.Speed:
                        playerMovement.SpeedUp();
                        break;
                    case ConsumableType.Double:
                        playerJump.DoubleJump();
                        break;
                    case ConsumableType.DevilFruit:

                        break;
                }
            }
            RemoveSelectedItem();
        }
    }

    public void OnDropButton()
    {
        ThrowItem(selectedItem);
        RemoveSelectedItem();
    }

    private void RemoveSelectedItem()
    {
        slots[selectedItemIndex].quantity--;

        if (slots[selectedItemIndex].quantity <= 0)
        {
            selectedItem = null;
            slots[selectedItemIndex].item = null;
            selectedItemIndex = -1;
            ClearSelectedItemWindow();
        }

        UpdateUI();
    }

    public void OnEquipButton()
    {
        if (slots[curEquipIndex].equipped)
        {
            UnEquip(curEquipIndex);
        }

        slots[selectedItemIndex].equipped = true;
        curEquipIndex = selectedItemIndex;
        CharacterManager.Instance.Player.equip.EquipNew(selectedItem);
        UpdateUI();

        SelectItem(selectedItemIndex);
    }

    private void UnEquip(int index)
    {
        slots[index].equipped = false;
        CharacterManager.Instance.Player.equip.UnEquip();
        UpdateUI();

        if (selectedItemIndex == index)
        {
            SelectItem(selectedItemIndex);
        }
    }

    public void OnUnEquipButton()
    {
        UnEquip(selectedItemIndex);
    }
}
