using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [Header("Movement")]
    public float forwardSpeed = 3.0f;
    public float forwardRunSpeed = 7.0f;
    public float backwardSpeed = 2.0f;
    public float rotateSpeed = 2.0f;
    public float RunningStamina = -5f;

    [Header("Jump")]
    public float jumpPower = 3.0f;
    public LayerMask groundLayerMask;

    [Header("Conditions")]
    [SerializeField] private float startHealth;
    [SerializeField] private float startHunger;
    [SerializeField] private float startStamina;

    public float StartHealth { get { return startHealth; } }
    public float StartHunger { get { return startHunger; } }
    public float StartStamina { get { return startStamina; } }
}
