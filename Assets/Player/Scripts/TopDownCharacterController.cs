using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public float speed;                 // The movement speed of the player.

    private Animator animator;          // Reference to the Animator component.

    private void Start()
    {
        // Get the Animator component attached to this object.
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 dir = Vector2.zero;     // Initialize a direction vector.

        // Check input keys for movement and set the direction and corresponding animation.
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);  // Set animation direction for left.
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);  // Set animation direction for right.
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);  // Set animation direction for up.
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);  // Set animation direction for down.
        }

        dir.Normalize();   // Normalize the direction vector to ensure consistent speed in all directions.

        // Set a boolean parameter to control the "IsMoving" animation state.
        animator.SetBool("IsMoving", dir.magnitude > 0);

        // Move the player using Rigidbody2D based on the calculated direction and speed.
        GetComponent<Rigidbody2D>().velocity = speed * dir;
    }
}
