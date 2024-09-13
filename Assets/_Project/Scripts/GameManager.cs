using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum Phase {
        Candles,
        Items,
        Ceremony,
        Chase
    }

    [SerializeField] private PlayerInteraction playerInteraction;
    [SerializeField] private Lamb lamb;
    [SerializeField] private Light[] lightArray;
    [SerializeField] private TextMeshProUGUI[] textArray;
    [SerializeField] private SlidingDoor[] doors;

    public static GameManager Instance;

    public Phase currentPhase = Phase.Candles;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        lamb.OnLambDeath += Lamb_OnLambDeath;
    }

    public PlayerInteraction GetPlayerInteraction() {
        return playerInteraction;
    }

    private void Lamb_OnLambDeath(object sender, System.EventArgs e) {
        foreach (Light light in lightArray) {
            light.color = Color.red;
        }

        foreach (TextMeshProUGUI text in textArray) {
            text.color = Color.red;
        }
    }

    public void LockDoors(bool value) {
        foreach (SlidingDoor door in doors) {
            door.SetCanOpen(value);
        }
    }
}
