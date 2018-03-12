using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPadController : MonoBehaviour {
    public float xAxis, yAxis;
    public int moveSpeed = 5;
    public Rigidbody2D blumpo;

    // Use this for initialization
    void Start() {

        blumpo = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update() {

        xAxis = Input.GetAxis("DPadX");
    yAxis = Input.GetAxis("DPadY");
    

        Vector2 movement = new Vector2(xAxis, yAxis);
            blumpo.velocity = movement * moveSpeed;
        
        

        if (xAxis != 0)
        {
            Debug.Log("asadad");
        }
        /*if (xAxis > 0.5f || xAxis < -0.5f)
        {
            transform.Translate(new Vector2(xAxis * moveSpeed * Time.deltaTime, 0));
        }
        if (yAxis > 0.5f || yAxis <-0.5f)
        {
            transform.Translate(new Vector2(0, yAxis * moveSpeed * Time.deltaTime));
        }*/

	}
}
