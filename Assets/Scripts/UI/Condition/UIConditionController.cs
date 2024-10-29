using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConditionController : MonoBehaviour
{
    public HealthConditionUI healthConditionUI;
    public HungerConditionUI hungerConditionUI;
    public StaminaConditionUI staminaConditionUI;

    private void Awake()
    {
        healthConditionUI = GetComponentInChildren<HealthConditionUI>();
        hungerConditionUI = GetComponentInChildren<HungerConditionUI>();
        staminaConditionUI = GetComponentInChildren<StaminaConditionUI>();
    }

}
