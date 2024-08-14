using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerCtrl : DestroyOBJ
{
    public PlayerMovement playerMovement;

    private void Start()
    {
        newOnInit();
    }

    private void Update()
    {
        if (!isDed)
        {
            DestroyByDistance(this);
        }
    }

    protected override void DestroyByDistance(PlayerCtrl other)
    {
        if (other.gameObject.transform.position.y < deadZone && !isDed)
        {
            base.DestroyByDistance(other);
            Die();
        }
    }

    public void newOnInit()
    {
        playerMovement.OnInit();
        isDed = false;
    }

    public void Die()
    {
        ParticlePool.Play(ParticleType.DieEff, transform.position, Quaternion.identity);
        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 0.1f);
        isDed = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Gate gate = Cache.GetGate(other);
        if (gate != null)
        {
            LevelManager.Ins.mapScr.CurLevel++;
            Observer.Notify("Wait", 1f, new Action(OpenAnim));
        }

        Spikes spike = Cache.GetSpikes(other);
        if (spike != null)
        {
            Debug.Log("Player Died");
            Die();
            LoadLevel();
        }
        
        Coin coins = Cache.GetCoins(other);
        if (coins != null)
        {
            coins.isTook();
        }

        ChangeMoveType changeMoveType = Cache.GetChangeMoveType(other);
        if (changeMoveType != null)
        {
            playerMovement.ChangeMoveType();
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 0.1f);
            changeMoveType.DeactiveBox();
        }
    }

    private void OpenAnim()
    {
        UIManager.Ins.OpenUI<AnimCanvas2>().OnInit2();
        Observer.Notify("Wait", 1f, new Action(LoadLevel));
    }

    private void LoadLevel()
    {
        LevelManager.Ins.mapScr.LoadLevel();
    }
}
