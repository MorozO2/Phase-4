using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapBehaviour : MonoBehaviour {

    public Transform sightStart, sightEnd, originalPos;

    public bool spotted = false; //detects if Blumpy is in the raycast of the trap

    public int speed = 2;

	void Update ()
    {
        RayCasting();
        Behaviours();
	}

    void RayCasting ()
    {
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.red);
        spotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << 2);// if linecast detects a collider, bool spotted will be set to true
    }

    void Behaviours ()
    {
        if (spotted == true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
    
}
