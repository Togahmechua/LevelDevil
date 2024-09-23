using System.Collections.Generic;
using UnityEngine;

public class SelectLevelUI : UICanvas
{
    [SerializeField] private GameObject[] listGOBJ;
    [SerializeField] private int gateNum;

    private void Start()
    {
        LoadGate();
    }

    public void LoadGate()
    {
        gateNum = LevelManager.Ins.curMap + 1;
        Debug.Log(gateNum);

        for (int i = 0; i < gateNum; i++)
        {
            listGOBJ[i].gameObject.SetActive(true);
        }

        if (gateNum == listGOBJ.Length - 1)
        {
            listGOBJ[listGOBJ.Length-1].gameObject.SetActive(true);
        }
    }

    public void ResetAllGate()
    {
        for (int i = 1; i < listGOBJ.Length; i++)
        {
            listGOBJ[i].gameObject.SetActive(false);
        }
    }
}