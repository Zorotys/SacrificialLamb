using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour {
    [SerializeField] private GameObject listGO;

    private void Start() {
        listGO.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            listGO.SetActive(!listGO.activeSelf);
        }
    }

}
