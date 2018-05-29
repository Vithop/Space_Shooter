using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Rotator : MonoBehaviour {

    public float tumble;

    private Rigidbody rb_a;

	void Start () {
        rb_a = GetComponent<Rigidbody>();

        rb_a.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	
}
