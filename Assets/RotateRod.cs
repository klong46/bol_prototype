using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRod : MonoBehaviour
{
    public Vector3 rotateAngle;
    public double rotationLimit;

    private void Update()
    {
        if (transform.rotation.y < (rotationLimit/100) && Input.GetKey(KeyCode.Space)) {
            transform.Rotate(rotateAngle/100);
        }
        
    }
}
