using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bol : MonoBehaviour
{

    private Rigidbody rb;
    private bool touchingBackboard = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -18, 0);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(1, 10, 9.7F);
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (touchingBackboard && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 0, -1);
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
