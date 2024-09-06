using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EvilLamb : MonoBehaviour {

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private DialogueTrigger dialogueTrigger;
    [SerializeField] private Animator animator;

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();

        GameManager.Instance.LockDoors(true);

        if (!DialogueManager.Instance.GetIsDialogueActive() && GameManager.Instance.currentPhase != GameManager.Phase.Chase) {
            StartCoroutine(StartDialogue());
        }
    }

    private void Update() {
        if (GameManager.Instance.currentPhase == GameManager.Phase.Chase) {
            animator.SetBool("IsWalking", true);
            rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
            return;
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            if (DialogueManager.Instance.GetLines().Count == 0) {
                SceneTransition.instance.StartTransition(2);
                return;
            }
            DialogueManager.Instance.DisplayNextDialogueLine();
        }
    }

    private IEnumerator StartDialogue() {
        yield return new WaitForSeconds(1f);
        dialogueTrigger.TriggerDialogue();
    }
}
