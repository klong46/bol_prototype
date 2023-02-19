using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bol : MonoBehaviour
{

    private Rigidbody rb;
    private bool touchingBackboard = false;

    public Vector3 startingPos;
    public int gravity;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -gravity, 0);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = startingPos;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
        if (touchingBackboard && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 0, -0.1F);
            touchingBackboard = false;
        }
    }

    private void OnCollisionEnter (Collision collisionInfo)
    {
        
        if (collisionInfo.gameObject.name == "Backboard")
        {
            touchingBackboard = true;
        }
    }
}
