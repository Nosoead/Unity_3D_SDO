using System;
using UnityEngine;


//이 스크립트는 강의와 동일한 상태로 들고와서 조금 추가했습니다.
//아이템을 적용시키기 위해 움직임(속도업)과 점프(더블점프)를 델꼬왔습니다.
//과제 처음에는 싱글톤에 대한 이해가 부족하여 최대한 이벤트만 쓰려다가
//한계를 느끼고 인스턴스의 의존성을 최대한 낮추기 위해 카테고리 밖의 데이터에
//접근할 때만 인스턴스로 접근하려고 싱글톤 만들고 거기 Player를 걸어놨습니다.
//폴더링도 Manager도 아니고 행동도 아니고 처리기도 아니고 애매해서 밖에 있습니다.
//이 스크립트는 어떻게 폴더링 해야할까요?
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
