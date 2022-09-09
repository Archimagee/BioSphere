using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private Camera targetCamera;
    [SerializeField]
    private float smoothTime;

    private Vector3 cameraOffset = new Vector3(0, 0, -10);
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetPosition = this.transform.position + cameraOffset;
        targetCamera.transform.position = Vector3.SmoothDamp(targetCamera.transform.position, targetPosition, ref velocity, smoothTime);
    }
}
