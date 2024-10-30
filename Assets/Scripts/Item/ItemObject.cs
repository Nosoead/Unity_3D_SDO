using UnityEngine;

//인터페이스에 대한 활용부분에 있어 이해도가 부족하여 강의내용을 그대로 들고 왔습니다.
//강의 내용에 의지하다 보니 2틀 안자고 봤을 때, 아 상자나 엘리베이터에도 그냥 함수만 쓰고 다른 내용 채워쓰면되네
//라고 생각했지만 뭔가 막상 사용하는 스크립트 보면 괴리감이 와서 
//그냥 잘 몰라서 강의내용 들고왔습니다.
public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemDataSO itemDataSO;

    public string GetInteractPrompt()
    {
        string str = $"{itemDataSO.displayName}\n{itemDataSO.description}";
        return str;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemDataSO = itemDataSO;
        CharacterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }
}
