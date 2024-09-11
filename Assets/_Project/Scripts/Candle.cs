using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : BaseInteractable {
    public enum CandleState {
        Unlit,
        Lit
    }
    private CandleState candleState = CandleState.Unlit;

    [SerializeField] private Candles candles;
    [SerializeField] private Pickable pickableNeeded;
    [SerializeField] private GameObject fireParticles;
    [SerializeField] private bool isLit = false;
    private bool hasNeededPickable;

    protected override void Update() {
        base.Update();
        if (playerInteraction.GetCurrentPickable() == pickableNeeded) {
            hasNeededPickable = true;
        } else {
            hasNeededPickable = false;
        }

        switch (candleState) {
            case CandleState.Unlit:
                if (hasNeededPickable) {
                    hoverText = "[E] Light Candle";
                } else {
                    hoverText = "Need a " + pickableNeeded.itemName;
                }
                break;
            case CandleState.Lit:
                if (hasNeededPickable) {
                    hoverText = "[E] Light Match";
                } else {
                    hoverText = "Need a " + pickableNeeded.itemName;
                }
                break;
        }

        hoverTextGameObject.text = hoverText;

        if (isLit) {
            fireParticles.SetActive(true);
            candleState = CandleState.Lit;
        } else {
            fireParticles.SetActive(false);
            candleState = CandleState.Unlit;
        }
    }

    public void LightCandle() {
        if (candles != null) {
            candles.AddCandle();
        }
        isLit = true;
    }

    public override void Interact(PlayerInteraction playerInteraction) {
        if (hasNeededPickable) {
            Match match = playerInteraction.GetCurrentPickable() as Match;
            if (!match.IsLit() && isLit) {
                match.LightMatch();
            }

            if (match.IsLit() && !isLit) {
                LightCandle();
            }
        }
    }

    public CandleState GetCandleState() {
        return candleState;
    }
}
