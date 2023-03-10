using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bol : MonoBehaviour
{

    private Rigidbody rb;
    private bool touchingBackboard = false;
    private CameraMovement cam;
    private GameOverCam mainCam;
    private RotateRod leftRod;
    private RotateRod rightRod;
    private MazeRotation maze;
    private HideShow text;

    public Vector3 startingPos;
    public int gravity;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -gravity, 0);
        cam = GameObject.Find("Camera").GetComponent<CameraMovement>();
        mainCam = GameObject.Find("Main Camera").GetComponent<GameOverCam>();
        leftRod = GameObject.Find("RodPivotLeft").GetComponent<RotateRod>();
        rightRod = GameObject.Find("RodPivotRight").GetComponent<RotateRod>();
        maze = GameObject.Find("Maze").GetComponent<MazeRotation>();
        text = GameObject.Find("GameOverText").GetComponent<HideShow>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = startingPos;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
        if (touchingBackboard && rb.velocity == Vector3.zero)
        {
            Vector3 pos = transform.position;
            pos.z -= 0.001F;
            transform.position = pos;
            touchingBackboard = false;
        }
    }

    private void OnCollisionEnter (Collision collisionInfo)
    {
        
        if (collisionInfo.gameObject.name == "Backboard" || collisionInfo.gameObject.name == "SeesawStartBase")
        {
            touchingBackboard = true;
        }
        if (collisionInfo.gameObject.name == "SeesawStartBase")
        {
            cam.ChangePos(1);
            leftRod.onRods = false;
            rightRod.onRods = false;

        }
        if (collisionInfo.gameObject.name == "MazeBase")
        {
            cam.ChangePos(2);
            maze.onMaze = true;
        }
        if (collisionInfo.gameObject.name == "Floor")
        {
            maze.onMaze = false;
            mainCam.GameOver();
            text.gameOver = true;
        }
    }
}
