using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InputHandler inputHandler;
    public PlayerConditionController conditionController;

    public ItemDataSO itemDataSO;
    public Action addItem;
    
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        inputHandler = GetComponent<InputHandler>();
        conditionController = GetComponent<PlayerConditionController>();
    }
}
