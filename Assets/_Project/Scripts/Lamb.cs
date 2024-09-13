using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lamb : BaseInteractable {
    public static Lamb Instance;

    public event EventHandler OnLambDeath;
    public event EventHandler OnOpenItemList;
    public event EventHandler OnLambDialogue;
    public event EventHandler OnEvilLambSpawn;

    [SerializeField] private DialogueTrigger dialogueTrigger;

    [SerializeField] private DialogueTrigger candleDialogue;
    [SerializeField] private DialogueTrigger itemDialogue;
    [SerializeField] private DialogueTrigger ceremonyDialogue;

    [SerializeField] private GameObject deathParticles;
    [SerializeField] private GameObject evilLamb;
    [SerializeField] private GameObject itemListGO;

    private const string CHARACTER_NAME = "Sheep";
    private GameManager gameManager;
    private bool ceremonyDialogueTriggered = false;
    private bool itemDialogueTriggered = false;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    private void Start() {
        gameManager = GameManager.Instance;
    }

    protected override void Update() {
        base.Update();

        if (gameManager != null) {
            switch (gameManager.currentPhase) {
                case GameManager.Phase.Candles:
                    dialogueTrigger.dialogue = candleDialogue.dialogue;
                    break;
                case GameManager.Phase.Items:
                    dialogueTrigger.dialogue = itemDialogue.dialogue;
                    break;
                case GameManager.Phase.Ceremony:
                    dialogueTrigger.dialogue = ceremonyDialogue.dialogue;
                    break;
            }  
        }

        
    }
    public override void Interact(PlayerInteraction playerInteraction) {
        if (ceremonyDialogueTriggered && DialogueManager.Instance.GetLines().Count == 0) {
            OnLambDeath?.Invoke(this, EventArgs.Empty);

            playerInteraction.GetCurrentPickable().DestroyPickable();
            playerInteraction.SetCurrentPickable(null);
            Vector3 offset = new Vector3(0, 0.5f, 0);
            GameObject go = Instantiate(deathParticles, transform.position + offset, Quaternion.identity);
            Destroy(go, 3f);

            Instantiate(evilLamb, transform.position, Quaternion.identity);
            OnEvilLambSpawn?.Invoke(this, EventArgs.Empty);

            Destroy(gameObject);
        }

        if (GameManager.Instance.currentPhase == GameManager.Phase.Items && itemDialogueTriggered && DialogueManager.Instance.GetLines().Count == 0) {
            OnOpenItemList?.Invoke(this, EventArgs.Empty);
        }

        if (GameManager.Instance.currentPhase == GameManager.Phase.Candles) {
            gameManager.LockDoors(false);
        }

        if (!DialogueManager.Instance.GetIsDialogueActive()) {
            dialogueTrigger.TriggerDialogue();
            OnLambDialogue?.Invoke(this, EventArgs.Empty);

            if (gameManager.currentPhase == GameManager.Phase.Ceremony) {
                ceremonyDialogueTriggered = true;
            } 
            if (gameManager.currentPhase == GameManager.Phase.Items) {
                itemDialogueTriggered = true;
            }
        } else {
            if (DialogueManager.Instance.GetLines().Count != 0) {
                if (DialogueManager.Instance.GetDialogueLine().character.name == CHARACTER_NAME) {
                    OnLambDialogue?.Invoke(this, EventArgs.Empty);
                }
            }
            DialogueManager.Instance.DisplayNextDialogueLine();
        }

    }
}
