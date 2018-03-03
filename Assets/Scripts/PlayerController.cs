using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Animator animate;
    private bool moving;
    private Vector2 lastmove;

	void Start () {

        animate = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        moving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            moving = true;
            lastmove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate( new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
            moving = true;
            lastmove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }


        animate.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
        animate.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
        animate.SetBool("PlayerMoving", moving);
        animate.SetFloat("LastMoveX", lastmove.x);
        animate.SetFloat("LastMoveY", lastmove.y);
    }
}
