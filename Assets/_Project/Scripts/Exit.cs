using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SceneTransition.instance.gameObject.GetComponentInChildren<Image>().color = Color.white;
            SceneTransition.instance.StartTransition(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("You Won");
        }
    }

}
