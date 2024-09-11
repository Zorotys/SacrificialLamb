using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

    [SerializeField] private GameObject creditsGO;

    public void OnPlayButton() {
        SceneTransition.instance.StartTransition(1);
    }

    public void OnCreditsButton() {
        creditsGO.SetActive(true);
    }

    public void OnHideCreditsButton() {
        creditsGO.SetActive(false);
    }

    public void ExitToDesktop() {
        Application.Quit();
    }

}
