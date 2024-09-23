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
    public bool endAnim;
    public bool endShakingScence;

    private List<Map> curMaplList = new List<Map>();
    

    private void Awake()
    {
        LevelManager.ins = this;
        OnInit();
    }

    public void OnInit()
    {
        curMap = PlayerPrefs.GetInt("CurrentMap", 0);
        mapSO.LoadWinStates();
    }

    public void ResetWinStates()
    {
        // Reset trạng thái chiến thắng cho tất cả các màn trong mapSO
        for (int i = 0; i < mapSO.mapList.Count; i++)
        {
            mapSO.mapList[i].isWon = false;
        }

        Debug.Log("Reset all win states");
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

    public void DestroyWhenEsc()
    {
        if (mapScr != null)
        {
            DespawnMap();
        }
    }

    public void WaitForPlayerInputToRestart()
    {
        StartCoroutine(WaitForInput());
    }

    private IEnumerator WaitForInput()
    {
        Debug.Log("Chờ nhấn phím...");

        yield return new WaitForSeconds(1f);  // Chờ 1 giây trước khi bắt đầu kiểm tra phím

        while (true)
        {
            if (Input.anyKeyDown)
            {
                Debug.Log("Phím được nhấn, load level...");
                mapScr.LoadLevel(); // Gọi load level
                yield break;
            }

            yield return null;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
