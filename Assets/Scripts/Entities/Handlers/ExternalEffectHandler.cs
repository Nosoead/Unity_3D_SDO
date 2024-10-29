using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalEffectHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        int PadLayer = LayerMask.NameToLayer("Pad");
        if (other.gameObject.layer == PadLayer)
        {
            JumpPad jumpPad = other.GetComponent<JumpPad>();
            if (jumpPad != null)
            {
                ApplyForce(jumpPad);
            }
        }
    }

    private void ApplyForce(JumpPad jumpPad)
    {
        rigidbody.velocity = new Vector3 (rigidbody.velocity.x, 0, rigidbody.velocity.z);
        rigidbody.AddForce(jumpPad.direction * jumpPad.jumpForce, jumpPad.forceMode);
    }
}
