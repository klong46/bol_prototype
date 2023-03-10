using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRod : MonoBehaviour
{
    public int direction;
    public bool onRods;
    private float mouseX;
    private float mouseOrigin;
    private float rotateOrigin;
    private float rotateAngle;
    private readonly int LIMIT = 12;
    private readonly int SCALE = 100;

    private void Start()
    {
        rotateOrigin = transform.rotation.eulerAngles.y;
        onRods = true;
    }

    private void Update()
    {
        if (onRods)
        {
            mouseX = Input.mousePosition.x;
            rotateAngle = (mouseOrigin - mouseX) / SCALE;
            float rotateY = (rotateAngle * direction) + rotateOrigin;
            rotateY = CheckLimits(rotateY);
            Vector3 angles = transform.rotation.eulerAngles;
            angles.y = rotateY;
            transform.eulerAngles = angles;
        }
    }

    private float CheckLimits(float rotateY)
    {
        if (direction == -1)
        {
            rotateY = Mathf.Clamp(rotateY, -LIMIT, 0);
            if (rotateY == -LIMIT || rotateY == 0)
            {
                mouseOrigin = mouseX;
                rotateOrigin = rotateY;
            }
        }
        else
        {
            rotateY = Mathf.Clamp(rotateY, 0, LIMIT);
            if (rotateY == 0 || rotateY == LIMIT)
            {
                mouseOrigin = mouseX;
                rotateOrigin = rotateY;
            }
        }
        return rotateY;
    }
}
