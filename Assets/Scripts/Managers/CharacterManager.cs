using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterManager : Singleton<CharacterManager>
{
    private Player player;
    public Player Player
    {
        //get
        //{
        //    if (player == null)
        //    {
        //        player = FindObjectOfType<Player>();  // ������ Player ã��
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
