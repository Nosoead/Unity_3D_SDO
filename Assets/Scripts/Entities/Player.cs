using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InputHandler inputHandler;
    public PlayerConditionController conditionController;
    public Equipment equip;
    public PlayerMovement movement;
    public PlayerJump jump;

    public ItemDataSO itemDataSO;
    public Action addItem;

    public Transform dropPosition;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        inputHandler = GetComponent<InputHandler>();
        conditionController = GetComponent<PlayerConditionController>();
        equip = GetComponent<Equipment>();
        movement = GetComponent<PlayerMovement>();
        jump = GetComponent<PlayerJump>();
    }
}
