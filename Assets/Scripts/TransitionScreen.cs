using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScreen : MonoBehaviour {

    
    public float timer = 5;

	void Start () {

       
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}
}
