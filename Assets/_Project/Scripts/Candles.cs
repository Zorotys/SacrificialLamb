using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Candles : MonoBehaviour {
    public static Candles Instance;

    public event EventHandler OnAllCandlesLit;

    [SerializeField] private Candle[] candles;

    [SerializeField] private int candlesLit = 0;
    private bool allCandlesLit = false;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    private void Update() {
        CheckCandles();
    }

    private void CheckCandles() {
        if (allCandlesLit) {
            return;
        }

        foreach (Candle candle in candles) {
            if (candlesLit == candles.Length) {
                GameManager.Instance.currentPhase = GameManager.Phase.Items;
                OnAllCandlesLit?.Invoke(this, EventArgs.Empty);
                allCandlesLit = true;
            }
        }
    }

    public void AddCandle() {
        candlesLit++;
    }

}
