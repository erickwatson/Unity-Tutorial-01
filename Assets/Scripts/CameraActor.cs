using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActor : MonoBehaviour {
    
    public float snapSpeed = 10;
    public Transform target;

    private Vector3 velocity = Vector3.zero;

    //private Vector3 boom;

    public Camera overHead;
    public Camera firstPerson;

    [HideInInspector]
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        // Get the vector from the target to us
       // boom = this.transform.position + target.position;
        overHead.enabled = true;
        firstPerson.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            overHead.enabled = !overHead.enabled;
            firstPerson.enabled = !firstPerson.enabled;
        }

        if (overHead.enabled)
        {
            // Set our position to be the same relative to the player
            Vector3 target_pos = target.position +  offset;

            this.transform.position = Vector3.Lerp(transform.position, target_pos, snapSpeed * Time.deltaTime);
        }

        if (firstPerson.enabled)
        { 

        }
    }
}
