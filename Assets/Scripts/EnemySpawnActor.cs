using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnActor : MonoBehaviour {

    public GameObject enemy_prefab;
    public GameObject spawner;
    public float spawn_time = 2;// seconds between spawns
    public int spawn_count = 7;
    public float spawn_radius; // distance from player to spawn
    public int enemy_max = 30;


    private PlayerActor player;
    private float spawn_timer; // The timer that counts and controls spawning


	// Use this for initialization
	void Start () {
        spawn_timer = spawn_time;
        player = GameObject.FindObjectOfType<PlayerActor>();
        
	}
	
	// Update is called once per frame
	void Update () {
        spawn_timer -= Time.deltaTime;

        var getCount = GameObject.FindGameObjectsWithTag("Enemy");
        int count = getCount.Length;

        if (spawn_timer < 0 && count < enemy_max)
        {
            // reset the timer
            spawn_timer = spawn_time;

            for (int i = 0; i < spawn_count; i++){

                if (count >= enemy_max)
                {
                    break;
                }
                
                //Pick a random angle in radians and set the spawn point
                float spawn_angle = Random.Range(0, 2 * Mathf.PI);
                Vector3 spawn_direction = new Vector3(Mathf.Sin(spawn_angle), 0, Mathf.Cos(spawn_angle));
                spawn_direction *= spawn_radius;

                Vector3 spawn_point = spawner.transform.position + spawn_direction;
                // Spawn the enemy at the desired location
                Instantiate(enemy_prefab, spawn_point, Quaternion.identity);

                count++;


                
            }
        }



	}
}

    
