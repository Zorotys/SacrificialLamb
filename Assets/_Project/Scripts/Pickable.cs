using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable {
    [SerializeField] private string itemName;
    private const string HAND_LAYER = "Hand";
    private const string DEFAULT_LAYER = "Default";

    public void Interact(PlayerInteraction playerInteraction) {
        SetParent(playerInteraction.GetHandTransform());
    }

    public void SetParent(Transform parentTransform) {
        transform.SetParent(parentTransform);
        transform.position = parentTransform.position;
        transform.rotation = parentTransform.rotation;

        Collider collider = GetComponent<Collider>();
        collider.enabled = false;

        gameObject.layer = LayerMask.NameToLayer(HAND_LAYER);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void ResetParent() {
        transform.SetParent(null);

        Collider collider = GetComponent<Collider>();
        collider.enabled = true;

        gameObject.layer = LayerMask.NameToLayer(DEFAULT_LAYER);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
}
