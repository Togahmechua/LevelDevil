using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager ins;
    public static LevelManager Ins => ins;
    public List<Map> mapList;
    private List<Map> curMaplList = new List<Map>();
    public Map mapScr;
    public int curMap;


    private void Awake()
    {
        LevelManager.ins = this;
        /*curMap = PlayerPrefs.GetInt("CurrentMap", 0);*/
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
                mapScr = SimplePool.Spawn<Map>(mapList[curMap]);
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
