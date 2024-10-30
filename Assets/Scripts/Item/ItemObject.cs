using UnityEngine;

//�������̽��� ���� Ȱ��κп� �־� ���ص��� �����Ͽ� ���ǳ����� �״�� ��� �Խ��ϴ�.
//���� ���뿡 �����ϴ� ���� 2Ʋ ���ڰ� ���� ��, �� ���ڳ� ���������Ϳ��� �׳� �Լ��� ���� �ٸ� ���� ä������ǳ�
//��� ���������� ���� ���� ����ϴ� ��ũ��Ʈ ���� �������� �ͼ� 
//�׳� �� ���� ���ǳ��� ���Խ��ϴ�.
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
