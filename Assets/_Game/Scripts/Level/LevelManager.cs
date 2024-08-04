using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager ins;
    public static LevelManager Ins => ins;
    public List<Map> mapList;
    public Map mapScr;
    public int curMap;


    private void Awake()
    {
        LevelManager.ins = this;
    }

    public void LoadMapByID(int id)
    {
        if (mapScr != null)
        {
            Destroy(mapScr.gameObject);
        }

        foreach (Map map in mapList)
        {
            if (map.id == id)
            {
                mapScr = Instantiate(mapList[curMap], transform);
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
