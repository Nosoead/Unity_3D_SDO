
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public ItemEquip curEquip;
    public Transform equipParent;

    private InputHandler inputHandler;

    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
    }

    public void EquipNew(ItemDataSO data)
    {
        UnEquip();
        Debug.Log("Equip");
        curEquip = Instantiate(data.equipPrefab, equipParent).GetComponent<ItemEquip>();
    }

    public void UnEquip()
    {
        if (curEquip != null)
        {
            Destroy(curEquip.gameObject);
            curEquip = null;
        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && curEquip != null)
        {
            Debug.Log("AttakInput");
            curEquip.OnAttackInput();
        }
    }
}