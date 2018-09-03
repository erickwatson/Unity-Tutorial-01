﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActor : MonoBehaviour {




    public float snapSpeed = 10;
    public Transform target;

    private Vector3 velocity = Vector3.zero;

    private Vector3 boom;

    [HideInInspector]
    public Vector3 offset;


	// Use this for initialization
	void Start () {
        // Get the vector from the target to us
        boom = this.transform.position + target.position;

    }
	
	// Update is called once per frame
	void Update () {
        
        // Set our position to be the same relative to the player
        Vector3 target_pos = target.position + boom + offset;

        this.transform.position = Vector3.Lerp(transform.position, target_pos, snapSpeed * Time.deltaTime);

    }
}
