﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DeathOnCollision : MonoBehaviour {

    
    public GameObject Door;
    public GameObject song;
    Animator anim;
    public bool dead = false;
    public playerController1 control;
    public Blink characterBlink;
    public Arrows arrows;

    void Start () {
        Door = GameObject.FindGameObjectWithTag("Door");
        song = GameObject.FindGameObjectWithTag("Audio");
        anim = GetComponent<Animator>();
        control = GetComponent<playerController1>();
        characterBlink = GetComponent<Blink>();
        arrows = GetComponent<Arrows>();

    }

	
	// Update is called once per frame
	void Update () {
        if (dead==true)
        {
            control.enabled = false;
            characterBlink.enabled = false;
            arrows.enabled = false;
            gameObject.layer = 10;
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Goo")
        {
            dead = true;
            Debug.Log("you died");
            anim.SetBool("dead", true);
            StartCoroutine(WaitBeforeNextScene(0.6f));

        }
        if(other.gameObject.tag == "PickUp")
            {
            Destroy(other.gameObject);
            Destroy(Door);
        }
        if (other.gameObject.tag == "Trigger")
        {
            Destroy(song);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    IEnumerator WaitBeforeNextScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
