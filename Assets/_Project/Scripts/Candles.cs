using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Candles : MonoBehaviour {

    [SerializeField] private Candle[] candles;

    [SerializeField] private int candlesLit = 0;
    private bool allCandlesLit = false;

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
                allCandlesLit = true;
            }
        }
    }

    public void AddCandle() {
        candlesLit++;
    }

}
