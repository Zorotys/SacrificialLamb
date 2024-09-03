using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lamb : BaseInteractable {
    private Pickable neededItem = null;

    [SerializeField] private DialogueTrigger dialogueTrigger;

    public override void Interact(PlayerInteraction playerInteraction) {
        if (!DialogueManager.Instance.GetIsDialogueActive()) {
            dialogueTrigger.TriggerDialogue();
        } else {
            DialogueManager.Instance.DisplayNextDialogueLine();
        }
    }
}
