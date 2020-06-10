using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject GameOverObject = null;
    [SerializeField] UnityChanControl UnityChanControl = null;
    public void gameOver()
    {
        GameOverObject.SetActive(true);
        UnityChanControl.GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }
    }
    void Restart()
    {
        GameOverObject.SetActive(false);
        UnityChanControl.Restart();
    }
}
