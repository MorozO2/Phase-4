using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeathOnCollision : MonoBehaviour {

    
    public GameObject Door;
   

    void Start () {
        Door = GameObject.FindGameObjectWithTag("Door");
        
    }

	
	// Update is called once per frame
	void Update () {
        
    }
    void OnCollisionEnter2D (Collision2D other)
    {
        
        if (other.gameObject.tag == "Goo")
        {
            
            Debug.Log("you died");            
            Application.LoadLevel("demo");

        }
        if(other.gameObject.tag == "PickUp")
            {
            Destroy(other.gameObject);
            Destroy(Door);
        }

        
    }
}
