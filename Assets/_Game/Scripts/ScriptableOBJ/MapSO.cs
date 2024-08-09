using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapSO", menuName = "ScriptableObjects/MapSO", order = 1)]
public class MapSO : ScriptableObject
{
    public List<MapDetails> mapList = new List<MapDetails>();


    [System.Serializable]
    public class MapDetails
    {
        public ELevel eLevel;
        public bool isWon;
    }
}

public enum ELevel
{
    None = 0,
    Level1 = 1,
    Level2 = 2,
    Level3 = 3, 
    Level4 = 4,
    Level5 = 5,
    Level6 = 6,
    Level7 = 7,
    Level8 = 8,
    Level9 = 9,
    Level10 = 10,
    Level11 = 11,
    Level12 = 12,
    Level13 = 13,
    Level14 = 14,
    Level15 = 15,
    Level16 = 16
}