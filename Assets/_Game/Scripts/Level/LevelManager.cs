using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager ins;
    public static LevelManager Ins => ins;

    public List<Map> mapList;
    public Map mapScr;
    public int curMap;
    public MapSO mapSO;
    public Image imgBackGround;

    private List<Map> curMaplList = new List<Map>();
    

    private void Awake()
    {
        LevelManager.ins = this;
        curMap = PlayerPrefs.GetInt("CurrentMap", 0);
        mapSO.LoadWinStates();
    }

    public void LoadMapByID(int id)
    {
        if (mapScr != null)
        {
            DespawnMap();
        }

        foreach (Map map in mapList)
        {
            if (map.id == id)
            {
               /* mapScr = Instantiate(mapList[curMap], transform);*/
                mapScr = SimplePool.Spawn<Map>(mapList[id]);
                mapScr.ResetState();
                curMaplList.Add(mapScr);
            }
        }
    }

    public void DespawnMap()
    {
        if (mapScr != null)
        {
            foreach (Map map in curMaplList)
            {
                mapScr.ResetState();
                SimplePool.Despawn(map);
            }
            curMaplList.Clear();
            mapScr = null;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
