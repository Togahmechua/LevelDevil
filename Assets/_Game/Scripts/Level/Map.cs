using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : GameUnit
{
    public Level level;
    public List<Level> levelList = new List<Level>();
    public int CurLevel;
    public int id;

    private void Awake()
    {
       /* CurLevel = PlayerPrefs.GetInt("CurrentLevel", 0);*/
        LoadLevel();
    }

    private void Update()
    {
        if (CurLevel > levelList.Count)
        {
            CurLevel = levelList.Count;

        }
    }

    public void LoadLevel()
    {
        if (level != null)
        {
            Destroy(level.gameObject);
        }

        level = Instantiate(levelList[CurLevel], transform);
    }

    public void NextLevel()
    {
        if (level != null)
        {
            Destroy(level.gameObject);
        }

        level = Instantiate(levelList[CurLevel], transform);
    }

    public void NewGame()
    {
        CurLevel = 0;
        /*PlayerPrefs.SetInt("CurrentLevel", CurLevel);
        PlayerPrefs.Save();*/
        LoadLevel();
    }

    public void ResetMap()
    {
        CurLevel--;
        if (CurLevel < 0) CurLevel = 0;
        LoadLevel();
    }
}
