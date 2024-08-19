using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject pauseMenu;

    private void Start() {
        pauseMenu.SetActive(false);
    }

    public void Resume() {
        gameState.currentState = GameState.State.Playing;
        pauseMenu.SetActive(false);
    }

}
