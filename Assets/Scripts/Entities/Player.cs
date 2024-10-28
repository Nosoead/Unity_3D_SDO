using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InputHandler inputHandler;
    public PlayerConditionController conditionController;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        inputHandler = GetComponent<InputHandler>();
        conditionController = GetComponent<PlayerConditionController>();
    }
}
