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

    public void RayGun()
    {
        Vector3 mouse_pos = Input.mousePosition;

        Ray mouse_ray = Camera.main.ScreenPointToRay(mouse_pos);

      
        Plane player_plane = new Plane(Vector3.up, transform.position);

        float ray_distance = 0;
        player_plane.Raycast(mouse_ray, out ray_distance);

        Vector3 cast_point = mouse_ray.GetPoint(ray_distance);

        Vector3 to_cast_point = cast_point - transform.position;
        to_cast_point.Normalize();
        Ray fire_ray = new Ray(transform.position, to_cast_point);

        RaycastHit info;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(fire_ray, out info))
        {
           if (info.collider.tag == "Enemy") 
            Destroy(info.collider.gameObject);
        }

    }
    // Update is called once per frame
    void Update () {

        KeyboardInput();
        RayGun();

    }
}
