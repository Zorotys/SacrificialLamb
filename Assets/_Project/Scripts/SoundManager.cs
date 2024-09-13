using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance;
    [SerializeField] private SoundEffectsSO soundEffectsSO;

    private float stepTimer = 0;
    private float stepInterval = 0.5f;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        Lamb.Instance.OnLambDeath += Lamb_OnLambDeath;
        Lamb.Instance.OnLambDialogue += Lamb_OnLambDialogue;
        Candles.Instance.OnAllCandlesLit += Candles_OnAllCandlesLit;
        Lamb.Instance.OnEvilLambSpawn += Lamb_OnEvilLambSpawn;
    }

    private void Update() {
        // Footsteps
        if (PlayerMovement.Instance.IsMoving()) {
            stepTimer += Time.deltaTime;

            if (stepTimer >= stepInterval) {
                PlaySound(soundEffectsSO.footSteps[Random.Range(0, soundEffectsSO.footSteps.Length)], PlayerMovement.Instance.transform.position, 0.10f);
                stepTimer = 0;
            }
        }
    }

    private void Lamb_OnEvilLambSpawn(object sender, System.EventArgs e) {
        EvilLamb.Instance.OnEvilLambDialogue += EvilLamb_OnEvilLambDialogue;
    }

    private void EvilLamb_OnEvilLambDialogue(object sender, System.EventArgs e) {
        PlaySound(soundEffectsSO.sheepEvil, EvilLamb.Instance.transform.position, 1);
    }

    private void Lamb_OnLambDialogue(object sender, System.EventArgs e) {
        PlaySound(soundEffectsSO.sheepShort, Lamb.Instance.transform.position, 1);
    }

    private void Candles_OnAllCandlesLit(object sender, System.EventArgs e) {
        PlaySound(soundEffectsSO.suspense, Camera.main.transform.position, 0.25f);
    }

    private void Lamb_OnLambDeath(object sender, System.EventArgs e) {
        PlaySound(soundEffectsSO.explosion, Lamb.Instance.transform.position, 1);
        PlaySound(soundEffectsSO.suspense, Camera.main.transform.position, 0.25f);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume) {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
