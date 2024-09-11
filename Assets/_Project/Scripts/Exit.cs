using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SceneTransition.instance.StartTransition(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
