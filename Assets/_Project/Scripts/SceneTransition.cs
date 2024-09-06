using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
    public static SceneTransition instance;

    [SerializeField] private Animator animator;

    const string TRIGGER_TRANSITION = "TriggerTransition";

    public void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void StartTransition(int scene) {
        StartCoroutine(ChangeScene(scene));
    }

    public IEnumerator ChangeScene(int scene) {
        animator.SetTrigger(TRIGGER_TRANSITION);
        SceneManager.LoadSceneAsync(scene);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
