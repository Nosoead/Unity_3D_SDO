using UnityEngine;


//�ܺο��� ������ ���� ��(�����е�), ���� �����ؾ��ϳ� ����ϴٰ�
// �÷��̾ Ʈ���� �߻��� �����͸� �޾� ������ �� �� ��ŭ �ö󰡴� ���� �´ٰ� �Ǵ��߽��ϴ�.
// �÷��̾ �ܺο��� � ȿ���� ������ ���⿡ �� ������ �ǰڴٰ� �����ϰ� �ֽ��ϴ�.
// ������� �� �׶� ī�װ��� ���� �ڵ带 ������ �� �� �����ϴ�.
public class ExternalEffectHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        int JumpPadLayer = LayerMask.NameToLayer("JumpPad");
        if (other.gameObject.layer == JumpPadLayer)
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
