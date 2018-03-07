using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DeathOnCollision : MonoBehaviour {

    
    public GameObject Door;
    Animator anim;

    void Start () {
        Door = GameObject.FindGameObjectWithTag("Door");
        anim = GetComponent<Animator>();
  
    }

	
	// Update is called once per frame
	void Update () {
    }
    void OnCollisionEnter2D (Collision2D other)
    {
        
        if (other.gameObject.tag == "Goo")
        {
            
            Debug.Log("you died");
            anim.SetBool("dead", true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(other.gameObject.tag == "PickUp")
            {
            Destroy(other.gameObject);
            Destroy(Door);
        }
        if (other.gameObject.tag == "Trigger")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
