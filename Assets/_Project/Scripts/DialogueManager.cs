using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
    public static DialogueManager Instance;

    [SerializeField] private GameObject dialogueGO;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI dialogue;
    [SerializeField] private float typingSpeed = 0.2f;

    public bool isDialogueActive = false;
    private Queue<DialogueLine> lines;

    private void Start() {
        if (Instance == null) {
            Instance = this;
        }

        lines = new Queue<DialogueLine>();
    }

    private void Update() {
        if (isDialogueActive) {
            dialogueGO.SetActive(true);
        } else {
            dialogueGO.SetActive(false);
        }
    }

    public void StartDialogue(Dialogue dialogue) {
        isDialogueActive = true;
        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines) {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine() {
        if (lines.Count == 0) {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterName.text = currentLine.character.name + ":";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    private IEnumerator TypeSentence(DialogueLine dialogueLine) {
        dialogue.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray()) {
            dialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void EndDialogue() {
        isDialogueActive = false;
    }

    public bool GetIsDialogueActive() {
        return isDialogueActive;
    }
}
