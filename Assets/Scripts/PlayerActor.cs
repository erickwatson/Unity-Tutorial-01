using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : MonoBehaviour {

    private CharacterController controller;
    public float speed = 5.0f;
	// Use this for initialization
	void Start () {
        controller = gameObject.GetComponent<CharacterController>();
	}


    public void KeyboardInput()
    { 
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 move_direction = new Vector3(1, 0, 0);
            controller.Move(move_direction* Time.deltaTime* speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 move_direction = new Vector3(-1, 0, 0);
            controller.Move(move_direction* Time.deltaTime* speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 move_direction = new Vector3(0, 0, 1);
            controller.Move(move_direction* Time.deltaTime* speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 move_direction = new Vector3(0, 0, -1);
            controller.Move(move_direction* Time.deltaTime* speed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 move_direction = new Vector3(0, 1, 0);
            controller.Move(move_direction* Time.deltaTime* speed);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Vector3 move_direction = new Vector3(0, -1, 0);
            controller.Move(move_direction* Time.deltaTime* speed);
        }
    }

	// Update is called once per frame
	void Update () {

        KeyboardInput();

    }
}
