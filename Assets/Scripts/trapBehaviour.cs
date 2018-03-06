using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapBehaviour : MonoBehaviour {

    public Transform sightStart, sightEnd;

    public bool spotted = false; //detects if Blumpy is in the raycast of the trap

    private bool dirUp = true;

    public int speed = 2;

	void Update ()
    {
        RayCasting();
        Behaviours();
	}

    void RayCasting ()
    {
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.red);
        spotted = Physics2D.Linecast(sightStart.position, sightEnd.position,1<<LayerMask.NameToLayer("Ignore Raycast")); // if linecast detects a collider, bool spotted will be set to true
    }

    void Behaviours ()
    {
        if (spotted == true)
        {
            if (dirUp)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.up * speed * Time.deltaTime);
            }
            if (transform.position.y >= 5)
            {
                dirUp = true;
            }
            if (transform.position.y <=-5)
            {
                dirUp = false;
            }
        }
    }
    
}
