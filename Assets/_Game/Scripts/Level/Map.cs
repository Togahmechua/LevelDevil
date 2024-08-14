using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : GameUnit
{
    public int id;
    public Level level;
    public List<Level> levelList = new List<Level>();
    public int CurLevel;
    public ELevel eLevl;

    private bool win;   

    private void Awake()
    {
        LoadLevel();
    }

    private void Update()
    {
        if (CurLevel >= levelList.Count && !win)
        {
            
            CurLevel = levelList.Count;
            //So sanh 2 enum neu enum giong nhau va chua win map (iswon = false) thi thay doi bool va tang curmap
            if (eLevl == LevelManager.Ins.mapSO.mapList[LevelManager.Ins.curMap].eLevel && LevelManager.Ins.mapSO.mapList[LevelManager.Ins.curMap].isWon == false)
            {
                LevelManager.Ins.mapSO.mapList[LevelManager.Ins.curMap].isWon = true;
                SaveWinState(LevelManager.Ins.curMap);
                Debug.Log("mapSO.mapList[CurLevel].isWon");
                LevelManager.Ins.curMap++; 
            }
            win = true;
            Observer.Notify("Wait", 1f, new Action(WaitDoorAnim));
        }
    }

    private void WaitDoorAnim()
    {
        UIManager.Ins.escUI.EscFunc();
        PlayerPrefs.SetInt("CurrentMap", LevelManager.Ins.curMap);
        PlayerPrefs.Save();
    }

    public void LoadLevel()
    {
        if (level != null)
        {
            Destroy(level.gameObject);
        }

        level = Instantiate(levelList[CurLevel], transform);
    }

    private void SaveWinState(int mapIndex)
    {
        string key = "MapWin_" + mapIndex;
        PlayerPrefs.SetInt(key, 1); // Save 1 to indicate the map is won
        PlayerPrefs.Save();
        LevelManager.Ins.mapSO.LoadWinStates();
    }
}
