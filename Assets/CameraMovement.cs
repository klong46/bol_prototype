using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera cam;
    private Vector3 pos1 = new(0, 27, -18);
    private Vector3 rot1 = new(63, 0, 0);

    private Vector3 pos2 = new(20, 16, -33);
    private Vector3 rot2 = new(14, -90, 0);

    private Vector3 pos3 = new(0.3f, 27, -18);
    private Animator anim;

    void Start()
    {
        

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position = pos1;
        transform.eulerAngles = rot1;
    }

    public void ChangePos(int moveNum)
    {
        if(moveNum == 1)
        {
            anim.SetTrigger("Part2");
        }else if(moveNum == 2)
        {
            anim.SetTrigger("Part3");
        }
    }

}
