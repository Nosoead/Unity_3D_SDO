using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputHandler : MonoBehaviour
{
    public UnityAction<Vector2> OnMoveEvent;
    public UnityAction<Vector2> OnLookEvent;
    public UnityAction<bool> OnJumpEvent;
    public UnityAction OnInteractionEvent;
    public UnityAction OnAttackEvent;
    public UnityAction<bool> OnVelocityUpEvent;
    public UnityAction OnInventoryEvent;
    public UnityAction OnSettingEvent;

    public PlayerInput Input;

    private void Awake()
    {
        Input = new PlayerInput();
    }

    private void OnEnable()
    {
        Input.Player.Move.performed += PlayerMove;
        Input.Player.Move.canceled += PlayerMove;
        Input.Player.Jump.performed += PlayerJump;
        Input.Player.Jump.canceled += PlayerJump;
        Input.Player.Interaction.performed += PlayerInteraction;
        Input.Player.Attack.performed += PlayerAttack;
        Input.Player.VelocityUp.performed += PlayerVelocityUp;
        Input.Player.VelocityUp.canceled += PlayerVelocityUp;
        Input.FirstLook.Look.performed += PlayerLook;
        Input.FirstLook.Look.canceled += PlayerLook;

        Input.PlayerToUI.ItemInventory.performed += PlayerInventory;
        Input.PlayerToUI.Setting.performed += PlayerSetting;


        Input.Player.Enable();
        Input.FirstLook.Enable();
        Input.PlayerToUI.Enable();
    }

    private void OnDisable()
    {
        Input.Player.Disable();
        Input.FirstLook.Disable();
        Input.PlayerToUI.Disable();
    }

    #region Event Invoke
    public void PlayerMove(InputAction.CallbackContext context)
    {
        Vector2 moveValue = context.ReadValue<Vector2>();
        OnMoveEvent?.Invoke(moveValue);
    }

    public void PlayerJump(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        bool isPressed = value > 0.5f;
        OnJumpEvent?.Invoke(isPressed);
    }

    public void PlayerInteraction(InputAction.CallbackContext context)
    {
        OnInteractionEvent?.Invoke();
    }

    public void PlayerAttack(InputAction.CallbackContext context)
    {
        OnAttackEvent?.Invoke();
    }

    public void PlayerVelocityUp(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        bool isPressed = value > 0.5f;
        OnVelocityUpEvent?.Invoke(isPressed);
    }

    public void PlayerLook(InputAction.CallbackContext context)
    {
        Vector2 LookValue = context.ReadValue<Vector2>();
        OnLookEvent?.Invoke(LookValue);
    }

    public void PlayerInventory(InputAction.CallbackContext context)
    {
        OnInventoryEvent?.Invoke();
    }

    public void PlayerSetting(InputAction.CallbackContext context)
    {
        OnSettingEvent?.Invoke();
    }
    #endregion
}
