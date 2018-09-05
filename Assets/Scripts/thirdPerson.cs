using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPerson : MonoBehaviour {

    [HideInInspector]
    public Transform target;
    public float snapSpeed = 10;

    public bool checkActive;
    
    public Vector3 offset;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        //// Set our position to be the same relative to the player
        Vector3 target_pos = target.position + offset;    
        transform.position = Vector3.Lerp(transform.position, target_pos, snapSpeed * Time.deltaTime);
    }
}
