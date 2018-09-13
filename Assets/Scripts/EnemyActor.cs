using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActor : MonoBehaviour {

    public float speed;
    private PlayerActor player;

    public GameObject OnDeathPrefab = null;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerActor>();

    }


    // Update is called once per frame
    void Update()
    {
        Vector3 dirToPlayer;
        dirToPlayer = player.transform.position - this.transform.position;
        dirToPlayer.Normalize();

        transform.position += dirToPlayer * speed * Time.deltaTime;

        
    }

    private void OnDestroy()
    {
        if (OnDeathPrefab != null)
        {
            GameObject.Instantiate(OnDeathPrefab, transform.position, transform.rotation);
        }
    }
}
