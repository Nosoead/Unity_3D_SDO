using UnityEngine;


//점프패드는 자신이 어떤 효과를 주는지만 자료를 들고 있고
//ExternalEffectHandler에게 충돌시 정보를 넘겨 플레이어 스스로 힘을 받습니다.
public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f;
    public Vector3 direction = Vector3.up;
    public ForceMode forceMode;
}
