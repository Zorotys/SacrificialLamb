using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public static MusicManager Instance;

    [SerializeField] private MusicSO musicSO;

    private AudioSource audioSource;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        switch (GameManager.Instance.currentPhase) {
            case GameManager.Phase.Candles:
                if (audioSource.clip != musicSO.gameMusic1) {
                    audioSource.clip = musicSO.gameMusic1;
                    audioSource.Play();
                }
                break;
            case GameManager.Phase.Items:
                if (audioSource.clip != musicSO.gameMusic2) {
                    audioSource.clip = musicSO.gameMusic2;
                    audioSource.Play();
                }
                break;
            case GameManager.Phase.Ceremony:
                if (audioSource.clip != musicSO.gameMusic3) {
                    audioSource.clip = musicSO.gameMusic3;
                    audioSource.Play();
                }
                break;
        }
    }
}
