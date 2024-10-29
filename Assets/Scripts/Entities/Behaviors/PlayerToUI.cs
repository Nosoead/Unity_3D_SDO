using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

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
