using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject pauseMenu;

    private void Start() {
        pauseMenu.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            if (gameState.currentState == GameState.State.Playing) {
                Pause();
            } else {
                Resume();
            }
        }
    }

    public void Resume() {
        gameState.currentState = GameState.State.Playing;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
    }

    public void Pause() {
        gameState.currentState = GameState.State.Paused;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
    }

}
