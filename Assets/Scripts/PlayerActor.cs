using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : MonoBehaviour {

    private CharacterController controller;
    public float speed = 5.0f;
    public float turnSpeed = 10.0f;

    public thirdPerson thirdPerson_cam = null;
    public firstPerson firstPerson_cam;


    public CameraActor camera_actor;

    Vector3 fly_up = new Vector3(0, 1, 0);
    Vector3 fly_down = new Vector3(0, -1, 0);




    private Vector3 PlatformGetPlayerFireDirection()
    {
        Vector3 mouse_pos =  Vector3.right * (Input.GetAxis("Mouse X") + Screen.width / 2.0f);

        Ray mouse_ray = Camera.main.ScreenPointToRay(mouse_pos);


        Plane player_plane = new Plane(Vector3.up, transform.position);

        float ray_distance = 0;
        player_plane.Raycast(mouse_ray, out ray_distance);

        Vector3 cast_point = mouse_ray.GetPoint(ray_distance);

        Vector3 to_cast_point = cast_point - transform.position;
        to_cast_point.Normalize();
        //Ray fire_ray = new Ray(transform.position, to_cast_point);

        return to_cast_point;
    }



    bool PlatformPlayerShouldFire()
    {
        return Input.GetMouseButtonDown(0);
    }
   
    
    // Use this for initialization
    void Start () {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void KeyboardInput()
    {
        float h_input = Input.GetAxis("Horizontal");
        float v_input = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h_input, 0, v_input);

        direction *= Time.deltaTime * speed;
        controller.Move(direction);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.Move(fly_down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            controller.Move(fly_up * Time.deltaTime * speed);
        }


    }



    public void RayGun()
    {
        // Make player face where they're shooting
        //Vector3 fire_direction = PlatformGetPlayerFireDirection();
        //transform.forward = fire_direction;
        
 //       if (transform.Find("thirdPerson").gameObject.activeInHierarchy)
       // {
            //transform.eulerAngles += Vector3.up * Input.GetAxis("Mouse X") * turnSpeed;
            Vector3 fire_direction = transform.forward;

            // Set offset to be equal to the fire_direction
           // thirdPerson_cam.offset = fire_direction;


            Ray fire_ray = new Ray(transform.position, fire_direction);

            RaycastHit info;
            if (Physics.Raycast(fire_ray, out info))
            {
                if (info.collider.tag == "Enemy")
                    Destroy(info.collider.gameObject);
            }
       // }
    }




    // Update is called once per frame
    void Update () {

        KeyboardInput();


        Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit info;
        
        if (Physics.Raycast(screenRay, out info))
        {
            Vector3 lookAtPoint = info.point;
            lookAtPoint.y = transform.position.y;
            transform.rotation = Quaternion.LookRotation(lookAtPoint - transform.position, Vector3.up);
        }


        //transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime);
        //Debug.Log("Horizontal axis:" + Input.GetAxis("Mouse X"));

        if (Input.GetMouseButtonDown(0))
            RayGun();

       
    }
}
