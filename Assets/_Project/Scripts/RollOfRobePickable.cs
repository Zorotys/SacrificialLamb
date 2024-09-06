using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollOfRobePickable : Pickable {
    [SerializeField] private Transform openTransform;
    [SerializeField] private Transform closedTransform;

    public void OpenRobe() {
        openTransform.gameObject.SetActive(true);
        closedTransform.gameObject.SetActive(false);
    }
}
