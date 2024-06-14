using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cache 
{
    private static Dictionary<Collider2D, PlayerCtrl> players = new Dictionary<Collider2D, PlayerCtrl>();

    public static PlayerCtrl GetCharacter(Collider2D collider)
    {
        if (!players.ContainsKey(collider))
        {
            players.Add(collider, collider.GetComponent<PlayerCtrl>());
        }

        return players[collider];
    }
    

    private static Dictionary<Collider2D, Gate> gates = new Dictionary<Collider2D, Gate>();

    public static Gate GetGate(Collider2D collider)
    {
        if (!gates.ContainsKey(collider))
        {
            gates.Add(collider, collider.GetComponent<Gate>());
        }

        return gates[collider];
    }
}
