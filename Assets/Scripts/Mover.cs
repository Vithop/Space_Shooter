using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;

    private Rigidbody rb_m;

    // Use this for initialization
    void Start () {
        rb_m = GetComponent<Rigidbody>();

        rb_m.velocity = transform.forward * speed;
    }
	
	
}
