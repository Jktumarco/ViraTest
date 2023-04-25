using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UI_CointsCount : MonoBehaviour
{
   
    [SerializeField] private int countCoints;
    public Text countCointsText;

    private void OnEnable()
    {
       UI_Controller.OnChangingCoints += ChangeCount;
    }

    void ChangeCount() { countCointsText.text = countCoints++.ToString(); }
    private void OnDisable()
    {
       UI_Controller.OnChangingCoints -= ChangeCount;
    }
}
