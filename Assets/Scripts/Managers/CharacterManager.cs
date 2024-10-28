using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterManager : Singleton<CharacterManager>
{
    private Player player;
    public Player Player
    {
        get { return player; }
        set { player = value; }
    }

}
