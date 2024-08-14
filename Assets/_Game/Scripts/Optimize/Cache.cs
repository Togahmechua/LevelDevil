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

    private static Dictionary<Collider2D, Spikes> spikes = new Dictionary<Collider2D, Spikes>();

    public static Spikes GetSpikes(Collider2D collider)
    {
        if (!spikes.ContainsKey(collider))
        {
            spikes.Add(collider, collider.GetComponent<Spikes>());
        }

        return spikes[collider];
    }

    private static Dictionary<Collider2D, Coin> coins = new Dictionary<Collider2D, Coin>();

    public static Coin GetCoins(Collider2D collider)
    {
        if (!coins.ContainsKey(collider))
        {   
            coins.Add(collider, collider.GetComponent<Coin>());
        }

        return coins[collider];
    }

    private static Dictionary<Collider2D, ChangeMoveType> changeMoveType = new Dictionary<Collider2D, ChangeMoveType>();

    public static ChangeMoveType GetChangeMoveType(Collider2D collider)
    {
        if (!changeMoveType.ContainsKey(collider))
        {
            changeMoveType.Add(collider, collider.GetComponent<ChangeMoveType>());
        }

        return changeMoveType[collider];
    }
}
