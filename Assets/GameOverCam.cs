using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCam : MonoBehaviour
{
    public void GameOver()
    {
        transform.position = new(0, 54, -184);
        transform.eulerAngles = new(19, 0, 0);
    }
}
