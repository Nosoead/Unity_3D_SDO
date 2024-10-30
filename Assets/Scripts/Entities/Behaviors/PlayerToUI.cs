using UnityEngine;

//UI를 띄우는 부분 입니다.
//OnInventory부분에서 구독을 해지하고 연결하는 것으로 InputActionMap을 재설정합니다.
//스탠다드반 InputAction 강의보고 감명받아서 구현해봤습니다.
public class PlayerToUI : MonoBehaviour
{
    private InputHandler inputHandler;
    bool isPlaying = true;
    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
    }

    private void OnEnable()
    {
        inputHandler.OnInventoryEvent += OnInventory;
        inputHandler.OnSettingEvent += OnSetting;
    }

    private void OnDisable()
    {
        inputHandler.OnInventoryEvent -= OnInventory;
        inputHandler.OnSettingEvent -= OnSetting;
    }

    private void Start()
    {
        UIManager.Instance.Inventory.SetActive(false);
    }
    private void OnInventory()
    {
        isPlaying = !isPlaying;
        Debug.Log(isPlaying);
        UIManager.Instance.Inventory.SetActive(!isPlaying);
        Cursor.lockState = isPlaying ? CursorLockMode.Locked : CursorLockMode.None;
        if (isPlaying)
        {
            inputHandler.Input.Player.Enable();
            inputHandler.Input.FirstLook.Enable();
            inputHandler.Input.UI.Disable();
        }
        else
        {
            inputHandler.Input.Player.Disable();
            inputHandler.Input.FirstLook.Disable();
            inputHandler.Input.UI.Enable();
        }
    }

    private void OnSetting()
    {

    }
}
