using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlots : MonoBehaviour {


    [SerializeField] private ItemSlot[] itemSlotArray;

    private int itemSlotsFilled = 0;
    private bool hasAllItems = false;

    private void Update() {
        if (GameManager.Instance.currentPhase == GameManager.Phase.Candles) {
            foreach (ItemSlot itemSlot in itemSlotArray) {
                itemSlot.gameObject.SetActive(false);
            }
        } else {
            foreach (ItemSlot itemSlot in itemSlotArray) {
                itemSlot.gameObject.SetActive(true);
            }
        }

        if (hasAllItems) {
            return;
        }

        foreach (ItemSlot itemSlot in itemSlotArray) {
            if (itemSlotsFilled == itemSlotArray.Length) {
                GameManager.Instance.currentPhase = GameManager.Phase.Ceremony;
                hasAllItems = true;
            }
        }


    }

    public void AddItemSlot() {
        itemSlotsFilled++;
    }

}
