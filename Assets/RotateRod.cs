using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRod : MonoBehaviour
{
    public int direction;
    private float mouseX;
    private float mouseOrigin;
    private float rotateOrigin;
    private float rotateAngle;
    private readonly int LIMIT = 12;
    private readonly int SCALE = 100;

    private void Start()
    {
        Recenter();
    }

    private void Update()
    {
        mouseX = Input.mousePosition.x;
        rotateAngle = (mouseOrigin - mouseX)/SCALE;       
        float rotateY = (rotateAngle * direction) + rotateOrigin;
        rotateY = CheckLimits(rotateY);
        Vector3 angles = transform.rotation.eulerAngles;
        angles.y = rotateY;
        transform.eulerAngles = angles;
    }

    private void Recenter()
    {
        mouseOrigin = mouseX;
        rotateOrigin = transform.rotation.eulerAngles.y;
    }

    private float CheckLimits(float rotateY)
    {
        if (direction == -1)
        {
            if (rotateY > 180)
            {
                rotateY -= 360;
            }
            rotateY = Mathf.Clamp(rotateY, -LIMIT, 0);
            if (rotateY == -LIMIT || rotateY == 0)
            {
                Recenter();
            }
        }
        else
        {
            rotateY = Mathf.Clamp(rotateY, 0, LIMIT);
            if (rotateY == 0 || rotateY == LIMIT)
            {
                Recenter();
            }
        }
        return rotateY;
    }
}
