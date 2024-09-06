using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable {
    public PlayerInteraction playerInteraction;
    public string itemName;
    public string hoverText;
    public TextMeshPro hoverTextGameObject;
    public GameObject[] hoverGameObjectArray;

    private const string HAND_LAYER = "Hand";
    private const string DEFAULT_LAYER = "Default";

    private bool hovered = false;

    public virtual void Interact(PlayerInteraction playerInteraction) {
        SetParent(playerInteraction.GetHandTransform(), true);
    }

    private void Start() {
        hoverTextGameObject.text = hoverText + " " + itemName;
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
        if (playerInteraction.GetHoveredPickable() == null) {
            hovered = false;
        } else {
            return;
        }
    }

    public void SetParent(Transform parentTransform, bool changeLayer) {
        transform.SetParent(parentTransform);
        transform.position = parentTransform.position;
        transform.rotation = parentTransform.rotation;

        Collider collider = GetComponent<Collider>();
        collider.enabled = false;

        if (changeLayer == true) {
            gameObject.layer = LayerMask.NameToLayer(HAND_LAYER);
            foreach (Transform child in transform) {
                child.gameObject.layer = LayerMask.NameToLayer(HAND_LAYER);
            }
        } else {
            gameObject.layer = LayerMask.NameToLayer(DEFAULT_LAYER);
            foreach (Transform child in transform) {
                child.gameObject.layer = LayerMask.NameToLayer(DEFAULT_LAYER);
            }
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void ResetParent() {
        transform.SetParent(null);

        Collider collider = GetComponent<Collider>();
        collider.enabled = true;

        gameObject.layer = LayerMask.NameToLayer(DEFAULT_LAYER);
        foreach (Transform child in transform) {
            child.gameObject.layer = LayerMask.NameToLayer(DEFAULT_LAYER);
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    public void SetHovered(bool setHovered) {
        hovered = setHovered;
    }

    public void DestroyPickable() {
        Destroy(gameObject);
    }
}
