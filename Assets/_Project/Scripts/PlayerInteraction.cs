using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    [SerializeField] private Transform handTransform;
    private Camera cam;

    private BaseInteractable hoveredInteractable;

    private Pickable currentPickable;
    private Pickable hoveredPickable;

    private void Start() {
        cam = Camera.main;
    }

    private void Update() {
        RaycastHit hit;
        float interactDistance = 3f;
        // Interact indicator
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactDistance)) {
            if (hit.collider.TryGetComponent(out BaseInteractable interactable)) {
                interactable.SetHovered(true);
                hoveredInteractable = interactable;
            } else {
                hoveredInteractable = null;
            }
            if (hit.collider.TryGetComponent(out Pickable pickable)) {
                pickable.SetHovered(true);
                hoveredPickable = pickable;
            } else {
                hoveredPickable = null;
            }
        } else {
            hoveredPickable = null;
            hoveredInteractable = null;
        }

        // Interact & Pick up item
        if (Input.GetKeyDown(KeyCode.E)) {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactDistance)) {
                if (hit.collider.TryGetComponent(out IInteractable interactable)) {
                    if (hit.collider.TryGetComponent(out BaseInteractable baseInteractable)) {
                        interactable.Interact(this);
                    }
                    if (hit.collider.TryGetComponent(out Pickable pickable)) {
                        if (currentPickable == null) {
                            currentPickable = pickable;
                            interactable.Interact(this);
                        }
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

    public Pickable GetCurrentPickable() {
        return currentPickable;
    }

    public void SetCurrentPickable(Pickable pickable) {
        currentPickable = pickable;
    }
    public Pickable GetHoveredPickable() {
        return hoveredPickable;
    }

    public BaseInteractable GetHoveredInteractable() {
        return hoveredInteractable;
    }
}
