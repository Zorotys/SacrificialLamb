using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour {
    [SerializeField] private GameObject listGO;
    [SerializeField] private Lamb lamb;
    
    private void Start() {
        listGO.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            listGO.SetActive(!listGO.activeSelf);
        }

        lamb.OnOpenItemList += Lamb_OnOpenItemList;
    }

    private void Lamb_OnOpenItemList(object sender, System.EventArgs e) {
        listGO.SetActive(true);
    }
}
