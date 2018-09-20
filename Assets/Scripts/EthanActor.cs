using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanActor : MonoBehaviour {

    private Animator animator;
    private float speed;
    private float direction;
    public float turn_speed = 3;
    public float acceleration = 3;
    public float jump_strength = 3;
	// Use this for initialization
	void Start () {
        // Get the Animator component
        animator = GetComponent<Animator>();
	}
	
    void PlayerControl()
    {
        float desired_direction = 0;
        if (Input.GetKey(KeyCode.A))
        {
            desired_direction = -1; // Turn Left
            if (Input.GetKey(KeyCode.LeftControl)) // If the player is turning left
            {
                desired_direction = -3;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            desired_direction = 1; // Turn right
            if (Input.GetKey(KeyCode.LeftControl)) // If the player is turning left
            {
                desired_direction = 3;
            }
        }
        // Interpolate direction
        direction = Mathf.Lerp(direction, desired_direction, turn_speed * Time.deltaTime);
        animator.SetFloat("direction", direction);

        // Jump


        //Idle Crouch

        float desired_speed = 0;
        if (!Input.anyKeyDown) // Check if any other keys are being pressed, if none,
                               // then the script steps in.
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                desired_speed = -1;
                speed = Mathf.Lerp(speed, desired_speed, acceleration * Time.deltaTime);
                animator.SetFloat("speed", speed);
            }



        }


     
        if (Input.GetKey(KeyCode.W)) // Move the player forward
        {
            desired_speed = 1; // if the player is moving forward
            if (Input.GetKey(KeyCode.LeftShift))
            {
                desired_speed = 2;
            }
        }
        speed = Mathf.Lerp(speed, desired_speed, acceleration * Time.deltaTime);
        animator.SetFloat("speed", speed);




    }

	// Update is called once per frame
	void Update () {
        PlayerControl();
	}
}
