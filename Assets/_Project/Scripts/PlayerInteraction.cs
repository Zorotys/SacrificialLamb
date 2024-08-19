using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    [SerializeField] private Transform handTransform;
    private Camera cam;

    private Pickable currentPickable;

    private void Start() {
        cam = Camera.main;
    }

    private void Update() {
        // Interact indicator

        // Interact & Pick up item
        if (Input.GetKeyDown(KeyCode.E)) {
            RaycastHit hit;
            float interactDistance = 3f;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactDistance)) {
                if (hit.collider.TryGetComponent(out IInteractable interactable)) {
                    if (hit.collider.TryGetComponent(out Pickable pickable)) {
                        if (currentPickable == null) {
                            currentPickable = pickable;
                            interactable.Interact(this);
                        }
                    } else {
                        interactable.Interact(this);
                    }
                }
            }
        }

        // Drop item
        if (Input.GetKeyDown(KeyCode.G)) {
            if (currentPickable != null) {
                currentPickable.ResetParent();
                currentPickable = null;
            }
        }
    }

    public Transform GetHandTransform() {
        return handTransform;
    }
}
