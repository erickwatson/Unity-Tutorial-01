using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {


    public Transform target;

    private Vector3 velocity = Vector3.zero;

    //private Vector3 boom;

    public Camera thirdPerson;
    public Camera firstPerson;



    // Use this for initialization
    void Start()
    {
        // Get the vector from the target to us
        // boom = this.transform.position + target.position;
        thirdPerson.gameObject.SetActive(true);
        firstPerson.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            thirdPerson.gameObject.SetActive(!thirdPerson.gameObject.activeSelf);
            firstPerson.gameObject.SetActive(!firstPerson.gameObject.activeSelf);
        }

    }
}
