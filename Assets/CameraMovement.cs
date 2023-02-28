using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera cam;
    private Vector3 pos1 = new(0.3f, 27, -18);
    private Vector3 rot1 = new(63, 0, 0);

    private Vector3 pos2 = new(20, 16, -33);
    private Vector3 rot2 = new(14, -90, 0);

    private Vector3 pos3 = new(0.3f, 27, -18);
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos1;
        transform.eulerAngles = rot1;
    }

    public void ChangePos()
    {
        transform.position = pos2;
        transform.eulerAngles = rot2;
    }

}
