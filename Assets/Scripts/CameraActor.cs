using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActor : MonoBehaviour {


    


    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    //private Vector3 boom;

	// Use this for initialization
	void Start () {
        // Get the vector from the target to us
        //boom = this.transform.position - target.position;

	}
	
	// Update is called once per frame
	void Update () {
        // Set our position to be the same relative to the player
        //Vector3 target_pos = target.position + boom;

        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));


        //this.transform.position = target_pos;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
