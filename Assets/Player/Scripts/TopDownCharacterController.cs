using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public float speed;    
    
    public Rigidbody2D rb;

    public float directionX;
    public float directionY;
    public bool UImode;

    public Animator[] animator;          
    
    Vector2  movement;

    private void Start()
    {
        // Get the Animator component attached to this object.
        //animator = GetComponent<Animator>();
    }

    public void PlayerModeUI(bool _mode)
    {
        UImode = _mode;
    }
    private void Update()
    {
        // Input
        if (!UImode)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            foreach (Animator _animator in animator)
            {
                _animator.SetFloat("Horizontal", movement.x);
                _animator.SetFloat("Vertical", movement.y);
                _animator.SetInteger("Speed", (int)movement.sqrMagnitude);

                if (movement != Vector2.zero)
                {
                    directionX = movement.x;
                    directionY = movement.y;
                    _animator.SetFloat("DirectionX", directionX);
                    _animator.SetFloat("DirectionY", directionY);
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6;
        }
        else { speed = 4; }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
