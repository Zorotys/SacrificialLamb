using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lamb : BaseInteractable {
    [SerializeField] private DialogueTrigger dialogueTrigger;

    [SerializeField] private DialogueTrigger candleDialogue;
    [SerializeField] private DialogueTrigger itemDialogue;
    [SerializeField] private DialogueTrigger ceremonyDialogue;

    public override void Interact(PlayerInteraction playerInteraction) {
        if (!DialogueManager.Instance.GetIsDialogueActive()) {
            dialogueTrigger.TriggerDialogue();
        } else {
            DialogueManager.Instance.DisplayNextDialogueLine();
        }
    }

    protected override void Update() {
        base.Update();

        GameManager gameManager = GameManager.Instance;
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
}
