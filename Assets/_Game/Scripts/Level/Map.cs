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

    private void Update()
    {
        if (CurLevel >= levelList.Count && !win)
        {
            CurLevel = levelList.Count;
            // So sánh và cập nhật trạng thái thắng của map
            if (eLevl == LevelManager.Ins.mapSO.mapList[LevelManager.Ins.curMap].eLevel &&
                LevelManager.Ins.mapSO.mapList[LevelManager.Ins.curMap].isWon == false)
            {
                LevelManager.Ins.mapSO.mapList[LevelManager.Ins.curMap].isWon = true;
                SaveWinState(LevelManager.Ins.curMap);
                Debug.Log("Map " + LevelManager.Ins.curMap + " is won.");
                LevelManager.Ins.curMap++;
            }
            win = true;
            Observer.Notify("Wait", 1f, new Action(WaitDoorAnim));
        }
    }


    public void ResetState()
    {
        // Reset lại các thuộc tính của map
        CurLevel = 0;
        win = false;

        // Hủy level hiện tại nếu có
        if (level != null)
        {
            Destroy(level.gameObject);
            level = null;
        }

        // Load lại level đầu tiên
        LoadLevel();
        Debug.Log("Map reset and first level loaded");
    }

    public void LoadLevel()
    {
        // Hủy level cũ nếu có trước khi load level mới
        if (level != null)
        {
            Destroy(level.gameObject);
        }

        // Load level hiện tại dựa trên CurLevel
        if (CurLevel < levelList.Count)
        {
            level = Instantiate(levelList[CurLevel], transform);
            Debug.Log("Load Level " + CurLevel);
        }
        else
        {
            Debug.LogWarning("CurLevel vượt quá số lượng level có sẵn");
        }
    }

    private void WaitDoorAnim()
    {
        UIManager.Ins.escUI.EscFunc();
        PlayerPrefs.SetInt("CurrentMap", LevelManager.Ins.curMap);
        PlayerPrefs.Save();
    }

    private void SaveWinState(int mapIndex)
    {
        string key = "MapWin_" + mapIndex;
        PlayerPrefs.SetInt(key, 1); // Lưu lại trạng thái thắng của map
        PlayerPrefs.Save();
        LevelManager.Ins.mapSO.LoadWinStates();
    }
}
