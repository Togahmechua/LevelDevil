using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void isTook()
    {
        this.gameObject.SetActive(false);
        ParticlePool.Play(ParticleType.CoinEff, transform.position, Quaternion.identity);
    }
}
