using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void LoadLevel3D(string level_name)
    {
        SceneManager.LoadScene(level_name);
    }

    public void LoadLevel2D(string level_name)
    {
        SceneManager.LoadScene(level_name);
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadLevel3D("Tute Game");
        }
	}
}
