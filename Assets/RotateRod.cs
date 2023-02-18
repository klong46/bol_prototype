using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRod : MonoBehaviour
{
    public Vector3 rotateAngle;
    public double rotationLimit;
    public int direction;

    private void Update()
    {
        if (Mathf.Abs(transform.rotation.y) < rotationLimit / 100) {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Rotate(rotateAngle * direction / 100);
            }
            else if(transform.rotation.y * direction > 0)
            {
                transform.Rotate(-rotateAngle * direction / 100);
            }
        }
        else
        {
            transform.Rotate(-rotateAngle * direction / 100);
        }
        
    }
}
