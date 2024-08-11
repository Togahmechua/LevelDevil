using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelState : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Sprite[] ArrImages;
    [SerializeField] private Image img;
    [SerializeField] private GameObject effect;
    [SerializeField] private int id;
    [SerializeField] private Color color;
 
    private void Start()
    {
        img.sprite = ArrImages[0];
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.sprite = ArrImages[1];
        effect.SetActive(true);
        LevelManager.Ins.imgBackGround.color = color;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.sprite = ArrImages[0];
        effect.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {  
        UIManager.Ins.OpenUI<AnimCanvas2>().OnInit2();
        UIManager.Ins.CloseUI<CursorCanvas>();
        Observer.Notify("Wait", 1f, new Action(TransToGamePlay));
    }

    private void TransToGamePlay()
    {
        LevelManager.Ins.LoadMapByID(id);
        UIManager.Ins.OpenUI<EscCanvasUI>().OnInitEsc();
        UIManager.Ins.CloseUI<SelectLevelUI>();
    }
}
