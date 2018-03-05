using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionFollow : MonoBehaviour {


    public GameObject followTarget;
    private Vector3 targetposition;
    public float speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        targetposition = new Vector3(4, 4, 4);
        transform.position = Vector3.Lerp(transform.position, targetposition, speed * Time.deltaTime);
    }
}
