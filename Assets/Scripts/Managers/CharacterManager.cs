using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;


//참조오류로 이것저것 다 해봤는데
//부모격에 Controller나 Manager(싱글톤아님)역할을 하는 애들한테 자식들 내용 영끌하게하고
//부모에 최종적으로 달려있으면 참조오류가 회피된다는 것을 알게 되었습니다.
public class CharacterManager : Singleton<CharacterManager>
{
    private Player player;
    public Player Player
    {
        //get //공부 기록용으로 남겨뒀습니다.
        //{
        //    if (player == null)
        //    {
        //        player = FindObjectOfType<Player>();  // 씬에서 Player 찾기
        //        if (player == null)
        //        {
        //            Debug.LogError("Player not found in the scene!");
        //        }
        //    }
        //    return player;
        //}
        //set
        //{
        //    if (value == null)
        //    {
        //        Debug.LogError("Trying to assign null to Player!");
        //        return;
        //    }
        //    player = value;
        //}
        get { return player; }
        set { player = value; }
    }

}
