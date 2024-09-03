using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour {

    private const string DOOR_TRIGGER = "DoorTrigger";
    [SerializeField] private bool canOpen = false;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (!canOpen) {
            return;
        }

        if (other.gameObject.CompareTag("Player")) {
            animator.SetTrigger(DOOR_TRIGGER);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (!canOpen) {
            return;
        }
        if (other.gameObject.CompareTag("Player")) {
            animator.SetTrigger(DOOR_TRIGGER);
        }
    }

}
