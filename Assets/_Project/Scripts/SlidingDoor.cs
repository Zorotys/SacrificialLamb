using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour {

    private const string DOOR_TRIGGER = "DoorTrigger";
    [SerializeField] private bool locked = true;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (locked) {
            return;
        }

        if (other.gameObject.CompareTag("Player")) {
            animator.SetTrigger(DOOR_TRIGGER);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (locked) {
            return;
        }
        if (other.gameObject.CompareTag("Player")) {
            animator.SetTrigger(DOOR_TRIGGER);
        }
    }

    public void SetCanOpen(bool value) {
        locked = value;
    }
}
