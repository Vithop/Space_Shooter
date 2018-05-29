using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}



public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public float fireRate;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;

    private Rigidbody rb_pc;
    private AudioSource a_w;
    private float nextFire;


    private void Start()
    {
        rb_pc = GetComponent<Rigidbody>();
        a_w = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            a_w.Play();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb_pc.velocity = movement * speed;

        rb_pc.position = new Vector3
            (
                Mathf.Clamp(rb_pc.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb_pc.position.z, boundary.zMin, boundary.zMax)
            );

        rb_pc.rotation = Quaternion.Euler(0.0f, 0.0f, rb_pc.velocity.x * -tilt);
    }
}
