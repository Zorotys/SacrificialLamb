using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float dialogueSpeed;
    [SerializeField] private string[] dialogueArray;
    private int index = 0;

    private void Start() {
        NextSentence();
        index = 0;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            NextSentence();
        }

        if (index == dialogueArray.Length) {
            StartCoroutine(DisableDialogue());
        }
    }

    private void NextSentence() {
        if (index <= dialogueArray.Length - 1) {
            dialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
    }

    private IEnumerator WriteSentence() {
        foreach (char character in dialogueArray[index].ToCharArray()) {
            dialogueText.text += character;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        index++;
    }

    private IEnumerator DisableDialogue() {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
