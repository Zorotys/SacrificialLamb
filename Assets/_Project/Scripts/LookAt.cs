using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private bool lookAtTarget;

    private void Start() {
        target = Camera.main.transform;
    }

    private void Update() {
        if (lookAtTarget) {
            transform.rotation = Quaternion.LookRotation(transform.position - target.position);
        }
    }

}
