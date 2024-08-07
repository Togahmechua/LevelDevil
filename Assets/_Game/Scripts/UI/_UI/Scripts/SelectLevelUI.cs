using System.Collections.Generic;
using UnityEngine;

public class SelectLevelUI : UICanvas
{
    [SerializeField] private GameObject[] listGOBJ;
    [SerializeField] private int gateIndex;

    private void Start()
    {
        LoadGate();
    }

    public void LoadGate()
    {
        gateIndex = LevelManager.Ins.curMap + 1;

        for (int i = 0; i < gateIndex; i++)
        {
            listGOBJ[i].gameObject.SetActive(true);
        }
    }
}