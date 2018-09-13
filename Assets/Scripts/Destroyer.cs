using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    [Range(0, 60)]
    public float TimeToLive = 1;

	// Use this for initialization
	IEnumerator Start ()
    {
        yield return new WaitForSeconds(TimeToLive);
        Destroy(gameObject);        
	}
	
}
