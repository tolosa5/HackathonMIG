using System;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private Rigidbody rb;
    private Transform grabPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!grabPoint)
            return;

        float lerpSpeed = 10f;
        Vector3 targetPosition = Vector3.Lerp(transform.position, grabPoint.position, Time.deltaTime * lerpSpeed);
        rb.MovePosition(targetPosition);
    }

    public void Grab(Transform grabPoint)
    {
        this.grabPoint.position = grabPoint.position;
        rb.useGravity = false;
    }

    public void Drop()
    {
        grabPoint = null;
        rb.useGravity = true;
    }
}
