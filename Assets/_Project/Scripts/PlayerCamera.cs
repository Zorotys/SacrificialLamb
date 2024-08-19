using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    [SerializeField] private float sensitivity = 100f;
    [SerializeField] private Transform orientation;

    private float rotX;
    private float rotY;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        // Mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

        rotY += mouseX;
        rotX -= mouseY;

        rotX = Mathf.Clamp(rotX, -90, 90);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        orientation.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
