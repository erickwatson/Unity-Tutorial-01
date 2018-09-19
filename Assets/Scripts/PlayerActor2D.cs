using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor2D : MonoBehaviour {


    public float speed;
    public float jump_speed;

    private Rigidbody2D rigid_body;

    private Animator animator;


    private bool grounded = true;
    private float grounded_timer = 0;

	// Use this for initialization
	void Start () {
        rigid_body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	

    void CheckCollisionsForGrounded (Collision2D hit)
    {
        for (int i = 0; i < hit.contacts.Length; i++)
        {
            //If the surface we hit is mostly facing up, treat as grounded
            if (Vector2.Dot(hit.contacts[i].normal, Vector2.up) > 0.75f)
            {
            grounded = true;
            grounded_timer = 0;
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D hit)
    {
        CheckCollisionsForGrounded(hit);
    }

    private void OnCollisionStay2D(Collision2D hit)
    {
        CheckCollisionsForGrounded(hit);
    }

    void PlayerControls ()
    {
        //// Store temp versions of velocity and scale
        Vector2 current_velocity = rigid_body.velocity;
        Vector3 scale = transform.localScale;
        if (Input.GetKey(KeyCode.A))
        {
            // Move left
            current_velocity.x = -speed;
            scale.x = 1; //ths is so the player is facing in the 'left' direction
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // move right
            current_velocity.x = speed;
            scale.x = -1; // this is so the player is facing in the 'right' direction
        }
        else
        {
            // Don't move
            current_velocity.x = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            // Jump
            current_velocity.y = jump_speed;
            grounded = false;
        }
        transform.localScale = scale;
        rigid_body.velocity = current_velocity;

        // If the collision system doesn't tell us we're on the ground
        // for over 0.2 seconds, treat us as not grounded
        grounded_timer += Time.deltaTime;
        if (grounded_timer > 0.2f)
        {
            grounded = false;
        }
    }    

	// Update is called once per frame
	void Update () {

        PlayerControls();

        animator.SetFloat("x_velocity", Mathf.Abs(rigid_body.velocity.x));
        animator.SetFloat("y_velocity", Mathf.Abs(rigid_body.velocity.y));
        ;

    }


}
