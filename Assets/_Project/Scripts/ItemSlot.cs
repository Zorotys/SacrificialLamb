using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : BaseInteractable {
    [SerializeField] private ItemSlots itemSlots;
    [SerializeField] private Pickable neededPickable;
    [SerializeField] private GameObject[] visualGameObjectArray;

    private bool hasItem = false;
    public override void Interact(PlayerInteraction playerInteraction) {
        if (playerInteraction.GetCurrentPickable() == neededPickable) {
            playerInteraction.GetCurrentPickable().SetParent(transform, false);
            playerInteraction.SetCurrentPickable(null);
            itemSlots.AddItemSlot();
            hasItem = true;
        }
    }

    protected override void Update() {
        base.Update();
        if (hasItem) {
            foreach (GameObject go in visualGameObjectArray) {
                go.SetActive(false);
            }
        }
    }

    public bool GetHasItem() {
        return hasItem;
    }
}
