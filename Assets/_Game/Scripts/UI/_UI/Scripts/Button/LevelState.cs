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

    private void Start()
    {
        img.sprite = ArrImages[0];
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.sprite = ArrImages[1];
        effect.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.sprite = ArrImages[0];
        effect.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        LevelManager.Ins.LoadMapByID(id);
        //Debug.Log("Onclick");
        UIManager.Ins.CloseUI<SelectLevelUI>();
        UIManager.Ins.OpenUI<AnimCanvas2>().OnInit2();
    }
}
