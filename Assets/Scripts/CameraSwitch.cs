using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {


    public Transform target;

    //private Vector3 velocity = Vector3.zero;

    //private Vector3 boom;

    public Camera thirdPerson;
    public Camera firstPerson;
    public Canvas reticule;
    public Camera leftMirror;
    public Camera rightMirror;
    public Camera miniMap;




    // Use this for initialization
    void Start()
    {
        thirdPerson.gameObject.SetActive(true);
        firstPerson.gameObject.SetActive(false);
        reticule.gameObject.SetActive(false);
        leftMirror.gameObject.SetActive(true);
        rightMirror.gameObject.SetActive(true);
        miniMap.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            thirdPerson.gameObject.SetActive(!thirdPerson.gameObject.activeSelf);
            firstPerson.gameObject.SetActive(!firstPerson.gameObject.activeSelf);
            reticule.gameObject.SetActive(!reticule.gameObject.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            leftMirror.gameObject.SetActive(!leftMirror.gameObject.activeSelf);
            rightMirror.gameObject.SetActive(!rightMirror.gameObject.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            miniMap.gameObject.SetActive(!miniMap.gameObject.activeSelf);
        }

    }
}
