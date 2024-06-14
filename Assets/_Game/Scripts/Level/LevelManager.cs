using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager ins;
    public static LevelManager Ins => ins;
    public Level level;
    public List<Level> levelList = new List<Level>();
    public int CurLevel;


    private void Awake()
    {
        LevelManager.ins = this;
        CurLevel = PlayerPrefs.GetInt("CurrentLevel", 0 );
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
        level = FindObjectOfType<Level>();
    }

    public void NextLevel()
    {
        if (level != null)
        {
            Destroy(level.gameObject);
        }
        
        level = Instantiate(levelList[CurLevel], transform);
        level = FindObjectOfType<Level>();
    }

    public void NewGame()
    {
        CurLevel = 0;
        PlayerPrefs.SetInt("CurrentLevel", CurLevel);
        PlayerPrefs.Save();
        LoadLevel();
    }

    public void ResetMap()
    {
        CurLevel--;
        if (CurLevel < 0) CurLevel = 0;
        LoadLevel();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
