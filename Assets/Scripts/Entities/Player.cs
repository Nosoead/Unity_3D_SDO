using System;
using UnityEngine;


//�� ��ũ��Ʈ�� ���ǿ� ������ ���·� ���ͼ� ���� �߰��߽��ϴ�.
//�������� �����Ű�� ���� ������(�ӵ���)�� ����(��������)�� �����Խ��ϴ�.
//���� ó������ �̱��濡 ���� ���ذ� �����Ͽ� �ִ��� �̺�Ʈ�� �����ٰ�
//�Ѱ踦 ������ �ν��Ͻ��� �������� �ִ��� ���߱� ���� ī�װ� ���� �����Ϳ�
//������ ���� �ν��Ͻ��� �����Ϸ��� �̱��� ����� �ű� Player�� �ɾ�����ϴ�.
//�������� Manager�� �ƴϰ� �ൿ�� �ƴϰ� ó���⵵ �ƴϰ� �ָ��ؼ� �ۿ� �ֽ��ϴ�.
//�� ��ũ��Ʈ�� ��� ������ �ؾ��ұ��?
public class Player : MonoBehaviour
{
    public InputHandler inputHandler;
    public PlayerConditionController conditionController;
    public Equipment equip;
    public PlayerMovement movement;
    public PlayerJump jump;

    public ItemDataSO itemDataSO;
    public Action addItem;

    public Transform dropPosition;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        inputHandler = GetComponent<InputHandler>();
        conditionController = GetComponent<PlayerConditionController>();
        equip = GetComponent<Equipment>();
        movement = GetComponent<PlayerMovement>();
        jump = GetComponent<PlayerJump>();
    }
}
