using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            newOnInit();
            isDed = true;
        }
    }

    public void newOnInit()
    {
        playerMovement.OnInit();
        isDed = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Gate gate = Cache.GetGate(other);
        if (gate != null)
        {
            LevelManager.Ins.CurLevel++;
            PlayerPrefs.SetInt("CurrentLevel" , LevelManager.Ins.CurLevel);
            LevelManager.Ins.NextLevel();
        }
    }
}
