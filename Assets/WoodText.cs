using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WoodText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI woodText;
    private int woodCount;

    void Awake()
    {
        woodCount = 0;
    }
    private void OnEnable()
    {
        Wood.OnWoodCollected += IncrementWoodCount;
    }
    private void OnDisable()
    {
        Wood.OnWoodCollected -= IncrementWoodCount;
    }
    void IncrementWoodCount()
    {
        woodCount++;
        woodText.text = $"{woodCount}";
    }
}
