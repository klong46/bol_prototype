using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawRotation : MonoBehaviour
{
    public int direction;
    public float speed;
    private float mouseX;
    private float mouseOrigin;
    private float rotateOrigin;
    private float rotateAngle;
    private readonly int LIMIT = 21;
    private readonly int SCALE = 100;

    private void Start()
    {
        Recenter();
    }

    private void Update()
    {
        mouseX = Input.mousePosition.x;
        rotateAngle = (mouseOrigin - mouseX) / SCALE * speed ;
        float rotateX = (rotateAngle * direction) + rotateOrigin;
        rotateX = CheckLimits(rotateX);
        Vector3 angles = transform.rotation.eulerAngles;
        angles.x = rotateX;
        transform.eulerAngles = angles;
    }

    private void Recenter()
    {
        mouseOrigin = mouseX;
        rotateOrigin = transform.rotation.eulerAngles.x;
        
    }

    private float CheckLimits(float rotateX)
    {
        rotateX = Mathf.Clamp(rotateX, -LIMIT, LIMIT);
        if (rotateX == -LIMIT || rotateX == LIMIT)
        {
            mouseOrigin = mouseX;
            rotateOrigin = rotateX;
        }
        return rotateX;
    }
}
