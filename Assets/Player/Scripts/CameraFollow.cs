using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // The target object to follow.
    public float lerpSpeed = 1.0f;      // The speed of interpolation (how fast the following happens).

    private Vector3 offset;             // The initial distance between the follower and the target.
    private Vector3 targetPos;          // The desired position for the follower.

    private void Start()
    {
        // Check if the target is assigned.
        if (target == null) return;

        // Calculate the initial offset between the follower and the target.
        offset = transform.position - target.position;
    }

    private void Update()
    {
        // Check if the target is assigned.
        if (target == null) return;

        // Calculate the desired position for the follower by adding the offset to the target's position.
        targetPos = target.position + offset;

        // Interpolate the current position of the follower towards the target position using lerpSpeed.
        // The interpolation smooths the movement over time.
        transform.position = target.position;
        //transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }
}







