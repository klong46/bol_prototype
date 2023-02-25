using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRotation : MonoBehaviour
{
    public int direction;
    public float speed;
    private float mouseX;
    private float mouseZ;
    private float mouseOriginX;
    private float mouseOriginZ;
    private float rotateOriginX;
    private float rotateOriginZ;
    private float rotateAngleX;
    private float rotateAngleZ;
    private readonly int LIMIT = 10;
    private readonly int SCALE = 100;

    void Start()
    {
        rotateOriginX = transform.rotation.eulerAngles.x;
        rotateOriginZ = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        Vector3 angles = transform.rotation.eulerAngles;
        angles.x = GetRotation(true);
        angles.z = GetRotation(false);
        transform.eulerAngles = angles;
    }

    private float CheckLimits(float rotate, bool isX)
    {
        rotate = Mathf.Clamp(rotate, -LIMIT, LIMIT);
        if (rotate == -LIMIT || rotate == LIMIT)
        {
            if (isX)
            {
                mouseOriginX = mouseX;
                rotateOriginX = rotate;
            }
            else
            {
                mouseOriginZ = mouseZ;
                rotateOriginZ = rotate;
            }

        }
        return rotate;
    }

    private float GetRotation(bool isX)
    {
        if (isX)
        {
            mouseX = Input.mousePosition.y;
            rotateAngleX = (mouseOriginX - mouseX) / SCALE * speed;
            float rotateX = (rotateAngleX * direction) + rotateOriginX;
            rotateX = CheckLimits(rotateX, isX);
            return rotateX;
        }

        mouseZ = Input.mousePosition.x;
        rotateAngleZ = (mouseOriginZ - mouseZ) / SCALE * speed;
        float rotateZ = (rotateAngleZ * -direction) + rotateOriginZ;
        rotateZ = CheckLimits(rotateZ, isX);
        return rotateZ;

    }
}
