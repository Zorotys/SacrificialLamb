using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform followTransform;

    private void Update() {
        transform.position = followTransform.position;
    }

}
