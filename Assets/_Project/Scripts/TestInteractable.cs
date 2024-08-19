using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable {
    public void Interact(PlayerInteraction playerInteraction) {
        Debug.Log("Interacted with TestInteractable");
    }
}
