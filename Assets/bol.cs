using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -12, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(1, 10, 9);
        }
    }
}
