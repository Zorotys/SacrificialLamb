using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : Pickable {

    [SerializeField] private GameObject fireParticles;
    private bool isLit = false;
    private bool holdingMatch = false;
    public override void Interact(PlayerInteraction playerInteraction) {
        if (!holdingMatch) {
            SetParent(playerInteraction.GetHandTransform(), true);
        }
    }

    protected override void Update() {
        base.Update();

        if (playerInteraction.GetCurrentPickable() == this) {
            holdingMatch = true;
        } else {
            holdingMatch = false;
        }
    }

    public void LightMatch() {
        fireParticles.SetActive(true);
        isLit = true;
    }

    public bool IsLit() {
        return isLit;
    }
}
