using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float cameraCurrentXRotation;
    public float lookSensitivity;

    private InputHandler inputHandler;

    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        inputHandler.OnLookEvent += OnLook;
    }

    private void OnDisable()
    {
        inputHandler.OnLookEvent -= OnLook;
    }

    private void LateUpdate()
    {
        ApplyLook();
    }

    private void OnLook(Vector2 mouseDelta)
    {
        cameraCurrentXRotation += mouseDelta.y * lookSensitivity;
        cameraCurrentXRotation = Mathf.Clamp(cameraCurrentXRotation, minXLook, maxXLook);
    }

    private void ApplyLook()
    {
        cameraContainer.localEulerAngles = new Vector3(-cameraCurrentXRotation, 0, 0);
    }
}
