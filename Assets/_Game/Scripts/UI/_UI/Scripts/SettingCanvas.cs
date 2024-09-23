using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingCanvas : UICanvas
{
    [SerializeField] private DeleteData deleteData;
    [SerializeField] private BackBtn backBtn;
    [SerializeField] private SoundBtn soundBtn;
    public void OnEnable()
    {
        deleteData.OnInit();
        backBtn.OnInit();
        soundBtn.OnInit();
        Debug.Log("Reset");
    }
}
