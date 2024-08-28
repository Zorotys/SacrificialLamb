using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamb : BaseInteractable {

    public override void Interact(PlayerInteraction playerInteraction) {
        if (playerInteraction.GetCurrentPickable() == null) {
            return;
        }

        Debug.Log("Gave " + playerInteraction.GetCurrentPickable().name + " To Lamb"); 
        RemoveCurrentPickable();
    }
}
