using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EvilLamb : MonoBehaviour {
    public static EvilLamb Instance;
    public event EventHandler OnEvilLambDialogue;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private DialogueTrigger dialogueTrigger;
    [SerializeField] private Animator animator;

    private const string CHARACTER_NAME = "Lord";
    private Rigidbody rb;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

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
            if (DialogueManager.Instance.GetLines().Count != 0) {
                if (DialogueManager.Instance.GetDialogueLine().character.name == CHARACTER_NAME) {
                    OnEvilLambDialogue?.Invoke(this, EventArgs.Empty);
                }
            }
            DialogueManager.Instance.DisplayNextDialogueLine();
        }
    }

    private IEnumerator StartDialogue() {
        yield return new WaitForSeconds(1f);
        dialogueTrigger.TriggerDialogue();
        OnEvilLambDialogue?.Invoke(this, EventArgs.Empty);
    }
}
