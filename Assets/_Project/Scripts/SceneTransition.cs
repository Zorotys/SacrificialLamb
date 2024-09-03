using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

    [SerializeField] private Animator animator;

    const string FADE_IN = "FadeIn";
    const string FADE_OUT = "FadeOut";

    private void Start() {
        animator.SetTrigger(FADE_OUT);
    }

    public void FadeIn() {
        animator.SetTrigger(FADE_IN);
    }

    public void FadeOut() {
        animator.SetTrigger(FADE_OUT);
    }
}
