using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable {

    void Interact(PlayerInteraction playerInteraction) {
        Debug.Log("Interacted with IInteractable");
    }

}
