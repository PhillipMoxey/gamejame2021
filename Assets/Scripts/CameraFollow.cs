using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public bool follow;

    public float smoothSpeed;

    public Vector3 cameraOffset;

    private Vector3 _smoothVel;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (follow)
        {
            Vector3 targetPosition = followTarget.position + cameraOffset;
            Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref _smoothVel, smoothSpeed);

            transform.position = smoothPosition;

            transform.LookAt(followTarget);
        }



    }
}
