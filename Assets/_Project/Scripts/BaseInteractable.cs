using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;

public class BaseInteractable : MonoBehaviour, IInteractable {

    public PlayerInteraction playerInteraction;
    public string itemName;
    public string hoverText;
    public TextMeshPro hoverTextGameObject;
    public GameObject[] hoverGameObjectArray;
    private bool hovered = false;

    public virtual void Interact(PlayerInteraction playerInteraction) {
        Debug.Log("Interacted with BaseInteractable");
    }

    protected virtual void Update() {
        if (hovered) {
            foreach (GameObject go in hoverGameObjectArray) {
                go.SetActive(true);
            }
        } else if (!hovered) {
            foreach (GameObject go in hoverGameObjectArray) {
                go.SetActive(false);
            }
        }

        if (playerInteraction == null) {
            return;
        }
        if (playerInteraction.GetHoveredInteractable() == null) {
            hovered = false;
        } else {
            return;
        }

        if (hoverTextGameObject != null) {
            hoverTextGameObject.text = hoverText + " " + itemName;
        }
    }

    public void SetHovered(bool setHovered) {
        hovered = setHovered;
    }

    public void RemoveCurrentPickable() {
        Destroy(playerInteraction.GetCurrentPickable().gameObject);
        playerInteraction.SetCurrentPickable(null);
    }
}
