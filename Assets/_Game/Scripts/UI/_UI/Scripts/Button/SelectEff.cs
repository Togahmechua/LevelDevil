using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEff : MonoBehaviour
{
    [SerializeField] private Text nameMap;
    [SerializeField] private string str;

    private void Start()
    {
        nameMap.text = str;
    }
}
