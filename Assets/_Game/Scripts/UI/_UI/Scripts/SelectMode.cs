using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMode : UICanvas
{
    [SerializeField] private Button singleMode;
    /*[SerializeField] private Button multiMode;*/

    void Start()
    {
        singleMode.onClick.AddListener(SelectLevelUI);
        /*multiMode.onClick.AddListener(SelectLevelUI);*/
    }

    private void SelectLevelUI()
    {
        this.gameObject.SetActive(false);
    }
}
