using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UI_Controller : MonoBehaviour
{
    [SerializeField] GameObject windowVictory;
    [SerializeField] GameObject windowDefeat;
    static public Action OnChangingCoints;
    static public Action OnVictory;
    static public Action OnDefeat;

    private void OnEnable()
    {
        OnVictory += OnActiveWindowVictory;
        OnDefeat += OnActiveWindowDefeat;
    }
    void OnActiveWindowVictory() { windowVictory.SetActive(true); }
    void OnActiveWindowDefeat() { windowDefeat.SetActive(true); }
    private void OnDisable()
    {
        OnVictory -= OnActiveWindowVictory;
        OnDefeat -= OnActiveWindowDefeat;
    }
}
