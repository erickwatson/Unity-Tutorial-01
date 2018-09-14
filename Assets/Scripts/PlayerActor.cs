using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : MonoBehaviour {

    private EnemyActor enemy_sound;
    private CharacterController controller;
    public float speed = 5.0f;
    public float turnSpeed;
    public float walkSpeed;
    public Vector3 jumpSpeed;
    public float jumpStrength; // could Vec3 this to get directional leaps
    public float mass = 3f;


    private Vector3 isGrounded;

    private firstPerson firstPerson_cam;
    private CameraSwitch checkCam;

    // FirstPerson variables
    private float rotX;
    private float rotY;
    public float MouseSensitivity;
    public float minY = -90;
    public float maxY = 90;
    public Transform camLook;

    public ParticleSystem hitscan_system;
    public AudioSource hitscan_sound;


    public float MoveSpeed;



    //Vector3 fly_up = new Vector3(0, 1, 0);
    //Vector3 fly_down = new Vector3(0, -1, 0);

    void Awake()
    {
        
    }

    // Use this for initialization
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        checkCam = gameObject.GetComponent<CameraSwitch>();
    }


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

        //if (hitscan_sound != null)
        //{
            
        //}

    
        return Input.GetMouseButtonDown(0);

    }




    public void KeyboardInput()
    {
        if (controller.isGrounded)
            jumpSpeed.Set(0, 0, 0);

        Vector3 direction = new Vector3(0, 0, 0);
        



        if (checkCam.thirdPerson.gameObject.activeSelf)
        {

            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            // ThirdPerson Camera mouse controls
            PlayerRotate();

            // ThirdPerson global keyboard controls
            float h_input = Input.GetAxis("Horizontal");
            float v_input = Input.GetAxis("Vertical");

            direction = new Vector3(h_input, 0, v_input);

            
            
        }

        if (checkCam.firstPerson.gameObject.activeSelf)
        {
            // FirstPerson keyboard controls
            // MouseLook();
            if (Cursor.lockState != CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            rotX += (Input.GetAxis("Mouse X")) * MouseSensitivity;
            rotY -= (Input.GetAxis("Mouse Y")) * MouseSensitivity;

            rotY = Mathf.Clamp(rotY, minY, maxY);
            transform.localRotation = Quaternion.Euler(0, rotX, 0);
            camLook.localRotation = Quaternion.Euler(rotY, 0, 0);


            float h_input = Input.GetAxis("Horizontal");
            float v_input = Input.GetAxis("Vertical");
            direction = new Vector3(h_input, 0, v_input);

            direction = transform.TransformDirection(direction);
            
       

        }

        direction *= speed;

        // Phsyics for jumping
        // change this
        jumpSpeed += Physics.gravity * mass * Time.deltaTime;

        

        //if (Input.GetKey(KeyCode.LeftControl))
        //{
        //   controller.Move(fly_down * Time.deltaTime * speed);
        //}
        //if (Input.GetKey(KeyCode.Space))
        //{
        //   controller.Move(fly_up * Time.deltaTime * speed);

        //}
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
          
            //Jump
            jumpSpeed += new Vector3(0, jumpStrength, 0);
          


        }

        // fall speed calculation
        direction += jumpSpeed;
        //Debug.Log(jumpSpeed);

        direction *= Time.deltaTime;
        controller.Move(direction);

    }



    public void RayGun()
    {

        hitscan_sound.Play();
        Vector3 fire_direction = transform.forward;
        Ray fire_ray = new Ray(transform.position, fire_direction);

        RaycastHit info;
        if (Physics.Raycast(fire_ray, out info))
        {
            if (info.collider.tag == "Enemy")
            {

                //info.collider.GetComponent<AudioSource>().Play();
                Destroy(info.collider.gameObject);
                
                
            }

            hitscan_system.Play();

        }

    }



    public void PlayerRotate()
    {
        Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit info;

        if (Physics.Raycast(screenRay, out info))
        {
            Vector3 lookAtPoint = info.point;
            lookAtPoint.y = transform.position.y;
            transform.rotation = Quaternion.LookRotation(lookAtPoint - transform.position, Vector3.up);
        }
    }



    // Update is called once per frame
    void Update () {

        KeyboardInput();

        // Fire
        if (Input.GetMouseButtonDown(0))
        RayGun();

       
    }
}
