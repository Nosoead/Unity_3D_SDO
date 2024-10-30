using UnityEngine;


//외부에서 영향을 받을 때(점프패드), 누가 연산해야하나 고민하다가
// 플레이어가 트리거 발생시 데이터를 받아 스스로 그 힘 만큼 올라가는 것이 맞다고 판단했습니다.
// 플레이어가 외부에서 어떤 효과를 받으면 여기에 다 넣으면 되겠다고 생각하고 있습니다.
// 길어지면 또 그때 카테고리에 맞춰 코드를 나눠야 할 것 같습니다.
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
