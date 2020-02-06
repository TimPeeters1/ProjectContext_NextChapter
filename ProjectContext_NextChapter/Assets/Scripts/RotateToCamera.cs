using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    Camera cam;
    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        transform.LookAt(cam.transform);
    }
}
