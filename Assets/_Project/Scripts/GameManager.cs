using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum Phase {
        Candles,
        Items,
        Ceremony
    }

    public static GameManager Instance;

    public Phase currentPhase = Phase.Candles;

    private void Start() {
        currentPhase = Phase.Candles;
    }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
}
