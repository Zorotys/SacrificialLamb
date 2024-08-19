using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public enum State {
        Playing,
        Paused
    }

    public State currentState;

    private void Start() {
        currentState = State.Playing;
    }

    private void Update() {
        switch (currentState) {
            case State.Playing:
                Time.timeScale = 1;
                break;
            case State.Paused:
                Time.timeScale = 0;
                break;
        }
    }
}
