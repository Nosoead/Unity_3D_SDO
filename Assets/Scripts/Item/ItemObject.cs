using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
