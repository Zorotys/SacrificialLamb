using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable {
    virtual void Interact(PlayerInteraction playerInteraction) {
        Debug.Log("Interacted with IInteractable");
    }

}
